Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Threading
Public Class ZlibStream
    Inherits DeflateStream
    Dim _hasRead As Boolean = False
    Private Shared ReadOnly BASE As UInteger = 65521
    Dim _checksum As UInteger
    ReadOnly _mode As CompressionMode
    ReadOnly _leaveOpen As Boolean
    Dim _stream As Stream
    Public Sub New(stream As Stream, mode As CompressionMode)
        Me.New(stream, mode, False)
    End Sub
    Public Sub New(stream As Stream, mode As CompressionMode, leaveOpen As Boolean)
        MyBase.New(stream, mode, True)
        _stream = stream
        _leaveOpen = leaveOpen
        _mode = mode
        If mode = CompressionMode.Compress Then
            Dim header As Byte() = {&H58, &H85}
            _stream.Write(header, 0, header.Length)
            _checksum = 1
        End If
    End Sub
    Public Overrides Function Read(array As Byte(), offset As Integer, count As Integer) As Integer
        If _hasRead = False Then
            Dim h1 As Integer = _stream.ReadByte()
            Dim h2 As Integer = _stream.ReadByte()
            _hasRead = True
        End If
        Return MyBase.Read(array, offset, count)
    End Function
    Public Overrides Function BeginRead(array As Byte(), offset As Integer, count As Integer, asyncCallback As AsyncCallback, asyncState As Object) As IAsyncResult
        Dim result As IAsyncResult = MyBase.BeginRead(array, offset, count, asyncCallback, asyncState)
        Return result
    End Function
    Public Overrides Sub Write(array As Byte(), offset As Integer, count As Integer)
        MyBase.Write(array, offset, count)
        Adler32(array, offset, count)
    End Sub
    Public Overrides Function BeginWrite(array As Byte(), offset As Integer, count As Integer, asyncCallback As AsyncCallback, asyncState As Object) As IAsyncResult
        Dim result As IAsyncResult = MyBase.BeginWrite(array, offset, count, asyncCallback, asyncState)
        Adler32(array, offset, count)
        Return result
    End Function
    Protected Overrides Sub Dispose(disposing As Boolean)
        MyBase.Dispose(disposing)
        If disposing AndAlso _mode = CompressionMode.Compress AndAlso _stream IsNot Nothing Then
            _stream.Write(BitConverter.GetBytes(_checksum), 0, 4)
            If Not _leaveOpen Then
                _stream.Close()
            End If
            _stream = Nothing
        End If
    End Sub
    Public Sub Adler32(buffer As Byte(), offset As Integer, count As Integer)
        If buffer Is Nothing Then
            Throw New ArgumentNullException("buffer")
        End If
        If offset < 0 OrElse count < 0 OrElse offset + count > buffer.Length Then
            Throw New ArgumentOutOfRangeException()
        End If
        Dim s1 As UInteger = _checksum And &HFFFF
        Dim s2 As UInteger = _checksum >> 16

        While count > 0
            Dim n As Integer = 3800
            If n > count Then
                n = count
            End If
            count -= n
            While Interlocked.Decrement(n) >= 0
                s1 = s1 + CUInt(buffer(Increment(offset)) And &HFF)
                s2 = s2 + s1
            End While
            s1 = s1 Mod BASE
            s2 = s2 Mod BASE
        End While
        _checksum = (s2 << 16) Or s1
    End Sub
    'i++
    Private Function Increment(value As Integer)
        Return Math.Max(Interlocked.Increment(value), value - 1)
    End Function
    'i--
    Private Function Decrement(value As Integer)
        Return Math.Max(Interlocked.Decrement(value), value + 1)
    End Function

End Class


Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class Encrypt
    Dim m_target As Byte()
    Dim md5s As String
    Private Property MD5() As String
        Get
            Return md5s
        End Get
        Set(value As String)
            md5s = value
        End Set
    End Property
    Private Property Target() As Byte()
        Get
            Return m_target
        End Get
        Set(value As Byte())
            m_target = value
        End Set
    End Property
    Public Sub New(taget As Byte())
        Me.Target = taget
    End Sub
    Public Sub New(target As Byte(), encode_md5 As String)
        Me.Target = target
        Me.MD5 = encode_md5
    End Sub
    Public Function EncryptSWF() As Byte()
        Dim i As Integer
        Dim _loc_2 As Byte() = New Byte(Me.Target.Length + 37) {}
        i = 0
        While i < 37
            _loc_2(i) = CType(i, Byte)
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Array.Copy(Me.Target, 0, _loc_2, 37, Me.Target.Length)
        Return _loc_2
    End Function
    Public Function EncryptPNGII() As Byte()
        Dim temp As Byte() = New Byte(Me.Target.Length + 18) {}
        Dim i As Integer
        i = 0
        While i < 21
            temp(i) = CType(i, Byte)
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Array.Copy(Me.Target, 124, temp, 21, temp.Length - 21 - 121)
        Array.Copy(Me.Target, 3, temp, 21 + temp.Length - 21 - 121, temp.Length - 21 - temp.Length + 21 + 121)
        Return temp
    End Function
    Public Function EncryptPNGX() As Byte()
        Dim temp As Byte() = New Byte(Me.Target.Length + 18 + 37) {}
        Dim md5_array As Byte() = Encoding.ASCII.GetBytes(Me.MD5)
        Dim i As Integer
        i = 0
        While i < 5
            temp(i) = CType(i, Byte)
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        i = 5
        While i < md5_array.Length
            temp(i) = md5_array(i)
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Dim temp2 As Byte() = New Byte(Me.Target.Length + 18) {}
        temp2 = Me.EncryptPNGII()
        Array.Copy(temp2, 0, temp, 37, temp2.Length)
        Return temp
    End Function
    Public Function EncryptSWFX() As Byte()
        Dim temp As Byte() = New Byte(Me.Target.Length + 37) {}
        Dim md5_array As Byte() = Encoding.ASCII.GetBytes(Me.MD5)
        Dim i As Integer
        i = 0
        While i < 5
            temp(i) = CType(i, Byte)
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        i = 5
        While i < md5_array.Length
            temp(i) = md5_array(i)
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Array.Copy(Me.Target, 0, temp, 37, Me.Target.Length)
        Return temp
    End Function

End Class

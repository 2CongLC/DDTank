Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO

Public Class Tile
    Dim _bh, _bw, _height, _width As Integer
    Dim _data As Byte()
    Dim _digable As Boolean
    Dim _rect As Rectangle
    Public Sub New(bitmap As Bitmap, digable As Boolean)
        Me._bh = 0
        Me._bw = 0
        Me._width = bitmap.Width
        Me._height = bitmap.Height
        Me._bw = (Me._width / 8) + 1
        Me._bh = Me._height
        Me._data = New Byte(Me._bw * Me._bh) {}
        Me._digable = digable
        Dim i As Integer = 0
        While i < bitmap.Height
            Dim j As Integer = 0
            While j < bitmap.Width
                Dim num3 As Byte = If((bitmap.GetPixel(j, i).A <= 100), (CType(0, Byte)), (CType(1, Byte)))
                Me._data((i * Me._bw) + (j / 8)) = CType((Me._data((i * Me._bw) + (j / 8)) Or (CType((num3 << (7 - (j Mod 8))), Byte))), Byte)
                System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)
            End While
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Me._rect = New Rectangle(0, 0, Me._width, Me._height)
    End Sub
    Public Sub New(files As String, digable As Boolean)
        Me._bw = 0
        Me._bh = 0
        Dim reader As New BinaryReader(File.Open(files, FileMode.Open))
        Me._width = reader.ReadInt32()
        Me._height = reader.ReadInt32()
        Me._bw = (Me._width / 8) + 1
        Me._bh = Me._height
        Me._data = reader.ReadBytes(Me._bw * Me._bh)
        Me._digable = digable
        Me._rect = New Rectangle(0, 0, Me._width, Me._height)
        reader.Close()
    End Sub
    Public Sub New(data As Byte(), width As Integer, height As Integer, digable As Boolean)
        Me._bw = 0
        Me._bh = 0
        Me._data = data
        Me._width = width
        Me._height = height
        Me._digable = digable
        Me._bw = (Me._width / 8) + 1
        Me._bh = Me._height
        Me._rect = New Rectangle(0, 0, Me._width, Me._height)
    End Sub
    Protected Sub Add(x As Integer, y As Integer, tile As Tile)
        Dim buffer As Byte() = tile._data
        Dim bound As Rectangle = tile.Bound
        bound.Offset(x, y)
        bound.Intersect(Me._rect)
        If (bound.Width <> 0) AndAlso (bound.Height <> 0) Then
            bound.Offset(-x, -y)
            Dim num As Integer = bound.X / 8
            Dim num2 As Integer = (bound.X + x) / 8
            Dim num3 As Integer = bound.Y
            Dim num4 As Integer = CType(Math.Floor(CType(((CType(bound.Width, Double)) / 8.0), Double)), Integer)
            Dim height As Integer = bound.Height
            Dim num6 As Integer = bound.X Mod 8
            Dim index As Integer = 0
            Dim num8 As Integer = 0
            Dim num9 As Integer = 0
            Dim num10 As Integer = 0
            Dim num11 As Integer = 0
            Dim i As Integer = 0
            While i < height
                num9 = 0
                num10 = 0
                Dim j As Integer = 0
                While j < num4
                    index = ((((i + y) + num3) * Me._bw) + j) + num2
                    num8 = (((i + num3) * tile._bw) + j) + num
                    num11 = buffer(num8)
                    num9 = num11 >> num6
                    Me._data(index) = CType((Me._data(index) Or (CType(num9, Byte))), Byte)
                    Me._data(index) = CType((Me._data(index) Or (CType(num10, Byte))), Byte)
                    num10 = num11 << (8 - num6)
                    System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)
                End While
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
        End If
    End Sub
    Public Function Clone() As Tile
        Return New Tile(TryCast(Me._data.Clone(), Byte()), Me._width, Me._height, Me._digable)
    End Function
    Public Sub Dig(cx As Integer, cy As Integer, surface As Tile, border As Tile)
        If Me._digable AndAlso (surface IsNot Nothing) Then
            Dim x As Integer = cx - (surface.Width / 2)
            Dim y As Integer = cy - (surface.Height / 2)
            Me.Remove(x, y, surface)
            If border IsNot Nothing Then
                x = cx - (border.Width / 2)
                y = cy - (border.Height / 2)
                Me.Add(x, y, surface)
            End If
        End If
    End Sub
    Public Function FindNotEmptyPoint(x As Integer, y As Integer, h As Integer) As Point
        If (x >= 0) AndAlso (x < Me._width) Then
            y = If((y < 0), 0, y)
            h = If(((y + h) > Me._height), (Me._height - y), h)
            Dim i As Integer = 0
            While i < h
                If Not Me.IsEmpty(x, y + i) Then
                    Return New Point(x, y + i)
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return New Point(-1, -1)
        End If
        Return New Point(-1, -1)
    End Function
    Public Function IsEmpty(x As Integer, y As Integer) As Boolean
        If (((x >= 0) AndAlso (x < Me._width)) AndAlso (y >= 0)) AndAlso (y < Me._height) Then
            Dim num As Byte = CType(((CType(1, Integer)) << (7 - (x Mod 8))), Byte)
            Return ((Me._data((y * Me._width) + (x / 8)) And num) = 0)
        End If
        Return True
    End Function
    Public Function IsRectangleEmptyQuick(rect As Rectangle) As Boolean
        rect.Intersect(Me._rect)
        Return (((Me.IsEmpty(rect.Right, rect.Bottom) AndAlso Me.IsEmpty(rect.Left, rect.Bottom)) AndAlso Me.IsEmpty(rect.Right, rect.Top)) AndAlso Me.IsEmpty(rect.Left, rect.Top))
    End Function
    Public Function IsYLineEmtpy(x As Integer, y As Integer, h As Integer) As Boolean
        If (x >= 0) AndAlso (x < Me._width) Then
            y = If((y < 0), 0, y)
            h = If(((y + h) > Me._height), (Me._height - y), h)
            Dim i As Integer = 0
            While i < h
                If Not Me.IsEmpty(x, y + i) Then
                    Return False
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            Return True
        End If
        Return True
    End Function
    Protected Sub Remove(x As Integer, y As Integer, tile As Tile)
        Dim buffer As Byte() = tile._data
        Dim bound As Rectangle = tile.Bound
        bound.Offset(x, y)
        bound.Intersect(Me._rect)
        If (bound.Width <> 0) AndAlso (bound.Height <> 0) Then
            bound.Offset(-x, -y)
            Dim num As Integer = bound.X / 8
            Dim num2 As Integer = (bound.X + x) / 8
            Dim num3 As Integer = bound.Y
            Dim num4 As Integer = CType(Math.Floor(CType(((CType(bound.Width, Double)) / 8.0), Double)), Integer)
            Dim height As Integer = bound.Height
            Dim num6 As Integer = bound.X Mod 8
            Dim index As Integer = 0
            Dim num8 As Integer = 0
            Dim num9 As Integer = 0
            Dim num10 As Integer = 0
            Dim num11 As Integer = 0
            Dim num12 As Integer = 0
            Dim i As Integer = 0
            While i < height
                num9 = 0
                num10 = 0
                Dim j As Integer = 0
                While j < num4
                    index = ((((i + y) + num3) * Me._bw) + j) + num2
                    num8 = (((i + num3) * tile._bw) + j) + num
                    num11 = buffer(num8)
                    num9 = num11 >> num6
                    num12 = Me._data(index)
                    num12 = num12 And Not (num12 And num9)
                    If num10 <> 0 Then
                        num12 = num12 And Not (num12 And num10)
                    End If
                    Me._data(index) = CType(num12, Byte)
                    num10 = num11 << (8 - num6)
                    System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)
                End While
                System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
            End While
        End If
    End Sub
    Public Function ToBitmap() As Bitmap
        Dim bitmap As New Bitmap(Me._width, Me._height)
        Dim i As Integer = 0
        While i < Me._height
            Dim j As Integer = 0
            While j < Me._width
                Dim num3 As Integer = j / 8
                Dim num4 As Byte = CType(((CType(1, Integer)) << (7 - (j Mod 8))), Byte)
                If (Me._data((i * Me._bw) + num3) And num4) = 0 Then
                    bitmap.SetPixel(j, i, Color.FromArgb(0, 0, 0, 0))
                Else
                    bitmap.SetPixel(j, i, Color.FromArgb(&HFF, 0, 0, 0))
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)
            End While
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Return bitmap
    End Function
    Public ReadOnly Property Bound() As Rectangle
        Get
            Return Me._rect
        End Get
    End Property
    Public ReadOnly Property Data() As Byte()
        Get
            Return Me._data
        End Get
    End Property
    Public ReadOnly Property Height() As Integer
        Get
            Return Me._height
        End Get
    End Property
    Public ReadOnly Property Width() As Integer
        Get
            Return Me._width
        End Get
    End Property
End Class

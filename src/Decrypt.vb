'Gunny
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Public Class Decrypt
    Dim m_target As Byte()
    Private Property Target() As Byte()
        Get
            Return m_target
        End Get
        Set(value As Byte())
            m_target = value
        End Set
    End Property
    Public Sub New(target As Byte())
        Me.Target = target
    End Sub
    Public Function DecryptSWF() As Byte()
        Dim _loc_2 As Byte() = New Byte(Me.Target.Length - 37) {}
        Array.Copy(Me.Target, 37, _loc_2, 0, Me.Target.Length - 37)
        Return _loc_2
    End Function
    Public Function DecryptPNGII() As Byte()
        Dim byteAvalible As Integer = Me.Target.Length - 21
        Dim temp As Byte() = New Byte(3 + Me.Target.Length - 21) {}
        temp(0) = CType(67, Byte)
        temp(1) = CType(87, Byte)
        temp(2) = CType(83, Byte)
        Array.Copy(Me.Target, 21, temp, 124, byteAvalible - 121)
        Array.Copy(Me.Target, 21 + byteAvalible - 121, temp, 3, Me.Target.Length - 21 - byteAvalible + 121)
        Return temp
    End Function
    Public Function DecryptPNGX() As Byte()
        Me.Target = DecryptSWF()
        Dim byteAvalible As Integer = Me.Target.Length - 21
        Dim temp As Byte() = New Byte(3 + Me.Target.Length - 21) {}
        temp(0) = CType(67, Byte)
        temp(1) = CType(87, Byte)
        temp(2) = CType(83, Byte)
        Array.Copy(Me.Target, 21, temp, 124, byteAvalible - 121)
        Array.Copy(Me.Target, 21 + byteAvalible - 121, temp, 3, Me.Target.Length - 21 - byteAvalible + 121)
        Return temp
    End Function
    Public Function DecryptSWFX() As Byte()
        Dim _loc_2 As Byte() = New Byte(Me.Target.Length - 37) {}
        Array.Copy(Me.Target, 37, _loc_2, 0, Me.Target.Length - 37)
        Return _loc_2
    End Function
    
End Class

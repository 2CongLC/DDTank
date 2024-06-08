Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Security.Cryptography
Imports zlib
Public Class main

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Shared Function GetBytesFromFile(fullFilePath As String) As Byte()
        Dim fs As FileStream = Nothing
        Try
            fs = New FileStream(fullFilePath, FileMode.Open, FileAccess.ReadWrite)
            Dim bytes As Byte() = New Byte(fs.Length) {}
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length))
            Return bytes
        Finally
            If fs IsNot Nothing Then
                fs.Close()
                fs.Dispose()
            End If
        End Try
    End Function
    Public Function IsDecrypted(param As Byte()) As Boolean
        If param(0) = 67 AndAlso param(1) = 87 AndAlso param(2) = 83 Then
            Return True
        End If
        Return False
    End Function
    Private Sub btswfen_Click(sender As Object, e As EventArgs) Handles cmd_swfencrypt.Click
        If openFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(openFileDialogs.FileName)
            If IsDecrypted(data) = False Then
                MessageBox.Show("Tệp tin đã được mã hóa")
            Else
                Dim encryptor As New Encrypt(data)
                Dim _loc_3 As Byte() = encryptor.EncryptSWF()
                Dim Writer As BinaryWriter = Nothing
                Try
                    Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                    Writer.Write(_loc_3)
                    Writer.Flush()
                    Writer.Close()
                    MessageBox.Show("Đã mã hóa xong tệp tin")
                Catch ex As Exception
                    MessageBox.Show("Xảy ra lỗi :" + ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub btpngIIen_Click(sender As Object, e As EventArgs) Handles cmd_png2encrypt.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(OpenFileDialogs.FileName)
            If Not IsDecrypted(data) Then
                MessageBox.Show("Tệp tin đã được mã hóa")
            Else
                Dim encryptor As New Encrypt(data)
                Dim _loc_3 As Byte() = encryptor.EncryptPNGII()
                Dim Writer As BinaryWriter = Nothing
                Try
                    Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                    Writer.Write(_loc_3)
                    Writer.Flush()
                    Writer.Close()
                    MessageBox.Show("Đã mã hóa xong tệp tin")
                Catch ex As Exception
                    MessageBox.Show("Xảy ra lỗi : " + ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub btswfxddten_Click(sender As Object, e As EventArgs) Handles cmd_swfxddtencrypt.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(OpenFileDialogs.FileName)
            If IsDecrypted(data) = False Then
                MessageBox.Show("Tệp tin đã được mã hóa")
            Else
                If txt_md5en.Text = "" Then
                    MessageBox.Show("Vui lòng điền đoạn MD5 của tệp tin" + OpenFileDialogs.FileName)
                Else
                    Dim encryptor As New Encrypt(data, txt_md5en.Text)
                    Dim _loc_3 As Byte() = encryptor.EncryptSWFX()
                    Dim Writer As BinaryWriter = Nothing
                    Try
                        Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                        Writer.Write(_loc_3)
                        Writer.Flush()
                        Writer.Close()
                        MessageBox.Show("Đã mã hóa xong tệp tin")
                    Catch ex As Exception
                        MessageBox.Show("Xảy ra lỗi :" + ex.ToString())
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub btpngxddten_Click(sender As Object, e As EventArgs) Handles cmd_ongxddtencrypt.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(OpenFileDialogs.FileName)
            If Not IsDecrypted(data) Then
                MessageBox.Show("File đã được mã hóa rồi !!!")
            Else
                If txt_md5en.Text = "" Then
                    MessageBox.Show("Vui lòng điền đoạn MD5 của file " + OpenFileDialogs.FileName)
                Else
                    Dim encryptor As New Encrypt(data, txt_md5en.Text)
                    Dim _loc_3 As Byte() = encryptor.EncryptPNGX()
                    Dim Writer As BinaryWriter = Nothing
                    Try
                        Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                        Writer.Write(_loc_3)
                        Writer.Flush()
                        Writer.Close()
                        MessageBox.Show("Đã mã hóa xong tệp tin")
                    Catch ex As Exception
                        MessageBox.Show("Xảy ra lỗi : " + ex.ToString())
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub btswfde_Click(sender As Object, e As EventArgs) Handles cmd_swfdecrypt.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(OpenFileDialogs.FileName)
            If IsDecrypted(data) Then
                MessageBox.Show("Tệp tin đã được giải mã")
            Else
                Dim decryptor As New Decrypt(data)
                Dim _loc_3 As Byte() = decryptor.DecryptSWF()
                Dim Writer As BinaryWriter = Nothing
                Try
                    Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                    Writer.Write(_loc_3)
                    Writer.Flush()
                    Writer.Close()
                    MessageBox.Show("Đã hoàn thành quá trình giải mã")
                Catch ex As Exception
                    MessageBox.Show("Xảy ra lỗi :" + ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub btpngIIde_Click(sender As Object, e As EventArgs) Handles cmd_png2decrypt.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(OpenFileDialogs.FileName)
            If IsDecrypted(data) Then
                MessageBox.Show("Tệp tin đã được giải mã")
            Else
                Dim decryptor As New Decrypt(data)
                Dim _loc_3 As Byte() = decryptor.DecryptPNGII()
                Dim Writer As BinaryWriter = Nothing
                Try
                    Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                    Writer.Write(_loc_3)
                    Writer.Flush()
                    Writer.Close()
                    MessageBox.Show("Đã hoàn thành quá trình giải mã")
                Catch ex As Exception
                    MessageBox.Show("Xảy ra lỗi : " + ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub btpngxddtde_Click(sender As Object, e As EventArgs) Handles cmd_pngxddtdecrypt.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(OpenFileDialogs.FileName)
            If IsDecrypted(data) Then
                MessageBox.Show("Tệp tin đã được giải mã")
            Else
                Dim decryptor As New Decrypt(data)
                Dim _loc_3 As Byte() = decryptor.DecryptPNGX()
                Dim Writer As BinaryWriter = Nothing
                Try
                    Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                    Writer.Write(_loc_3)
                    Writer.Flush()
                    Writer.Close()
                    MessageBox.Show("Đã hoàn thành quá trình giải mã")
                Catch ex As Exception
                    MessageBox.Show("Xảy ra lỗi : " + ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub btswfxddtde_Click(sender As Object, e As EventArgs) Handles cmd_swfxddtdecrypt.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Dim data As Byte() = GetBytesFromFile(OpenFileDialogs.FileName)
            If IsDecrypted(data) Then
                MessageBox.Show("Tệp tin đã được giải mã")
            Else
                Dim decryptor As New Decrypt(data)
                Dim _loc_3 As Byte() = decryptor.DecryptSWFX()
                Dim Writer As BinaryWriter = Nothing
                Try
                    Writer = New BinaryWriter(File.OpenWrite(SaveFileDialogs.FileName))
                    Writer.Write(_loc_3)
                    Writer.Flush()
                    Writer.Close()
                    MessageBox.Show("Đã hoàn thành quá trình giải mã")
                Catch ex As Exception
                    MessageBox.Show("Xảy ra lỗi :" + ex.ToString())
                End Try
            End If
        End If
    End Sub

    Private Sub cmd_xmlcompress_Click(sender As Object, e As EventArgs) Handles cmd_xmlcompress.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Using input As FileStream = File.Open(OpenFileDialogs.FileName, FileMode.Open)
                Using output As FileStream = File.Create(SaveFileDialogs.FileName)
                    Using Z As New ZlibStream(output, Compression.CompressionMode.Compress, True)
                        input.CopyTo(Z)
                        MsgBox("Đã hoàn thành quá trình mã hóa")
                    End Using
                End Using
            End Using
        End If
    End Sub

    Public Function MD5_en_text(input As String)
        Dim UTF8_Encoding As New UTF8Encoding
        Dim MD5 As New MD5CryptoServiceProvider()
        Dim Buffer As Byte() = UTF8_Encoding.GetBytes(input)
        Buffer = MD5.ComputeHash(Buffer)
        Dim output As String = Nothing
        For Each bt As Byte In Buffer
            output &= bt.ToString("x2")
        Next
        Return output
    End Function
    Private Sub cmd_gethash_Click(sender As Object, e As EventArgs) Handles cmd_gethash.Click
        If OpenFileDialogs.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt_md5en.Text = MD5_en_text(OpenFileDialogs.FileName)
        End If
    End Sub

    Private Sub cmd_xmlDecompress_Click(sender As Object, e As EventArgs) Handles cmd_xmlDecompress.Click
        If OpenFileDialogs.ShowDialog() = DialogResult.OK AndAlso SaveFileDialogs.ShowDialog() = DialogResult.OK Then
            Using input As FileStream = File.Open(OpenFileDialogs.FileName, FileMode.Open)
                Using output As FileStream = File.Create(SaveFileDialogs.FileName)
                    Using Z As New ZlibStream(input, Compression.CompressionMode.Decompress, False)
                        Z.CopyTo(output)
                        MsgBox("Đã hoàn thành quá trình giải mã")
                    End Using
                End Using
            End Using
        End If
    End Sub

    Dim bitmap As Bitmap
    Dim tile As Tile
    Dim writer As BinaryWriter
    Dim Stream As FileStream
    Private Sub cmd_make_Click(sender As Object, e As EventArgs) Handles cmd_make.Click
        If OpenFileDialogs.ShowDialog = Windows.Forms.DialogResult.OK AndAlso SaveFileDialogs.ShowDialog = Windows.Forms.DialogResult.OK Then
            bitmap = New Bitmap(OpenFileDialogs.FileName)
            tile = New Tile(bitmap, True)
            Stream = File.Create(SaveFileDialogs.FileName)
            writer = New BinaryWriter(Stream)
            writer.Write(tile.Width)
            writer.Write(tile.Height)
            writer.Flush()
            Stream.Write(tile.Data, 0, tile.Data.Length)
            Stream.Close()
            MsgBox("Đã hoàn thành quá trình tạo map")
        End If
    End Sub
    Sub Saveimages()
        bitmap = New Bitmap(New Tile(OpenFileDialogs.FileName, True).ToBitmap)
        bitmap.Save(SaveFileDialogs.FileName, System.Drawing.Imaging.ImageFormat.Png)
        bitmap.Dispose()
        MsgBox("Đã hoàn thành quá trình lưu ảnh")
    End Sub
    Private Sub cmd_test_Click(sender As Object, e As EventArgs) Handles cmd_test.Click
        If OpenFileDialogs.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                PB_map.Image = New Tile(OpenFileDialogs.FileName, True).ToBitmap
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub saveas_Click(sender As Object, e As EventArgs) Handles saveas.Click

        If SaveFileDialogs.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                'Dim bitmap As Bitmap = New Bitmap(PB_map.Image)
                PB_map.Image.Save(SaveFileDialogs.FileName, System.Drawing.Imaging.ImageFormat.Png)
                PB_map.Image.Dispose()
                MsgBox("Đã hoàn thành quá trình lưu ảnh")
            Catch ex As Exception

            End Try
End If
        
    End Sub
End Class

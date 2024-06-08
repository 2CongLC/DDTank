<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.TabControls = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.cmd_xmlcompress = New System.Windows.Forms.Button()
        Me.cmd_ongxddtencrypt = New System.Windows.Forms.Button()
        Me.Grmd5en = New System.Windows.Forms.GroupBox()
        Me.cmd_gethash = New System.Windows.Forms.Button()
        Me.txt_md5en = New System.Windows.Forms.TextBox()
        Me.cmd_swfxddtencrypt = New System.Windows.Forms.Button()
        Me.cmd_png2encrypt = New System.Windows.Forms.Button()
        Me.cmd_swfencrypt = New System.Windows.Forms.Button()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.cmd_xmlDecompress = New System.Windows.Forms.Button()
        Me.cmd_pngxddtdecrypt = New System.Windows.Forms.Button()
        Me.cmd_swfxddtdecrypt = New System.Windows.Forms.Button()
        Me.cmd_png2decrypt = New System.Windows.Forms.Button()
        Me.cmd_swfdecrypt = New System.Windows.Forms.Button()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.GB_View = New System.Windows.Forms.GroupBox()
        Me.PB_map = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrips = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.saveas = New System.Windows.Forms.ToolStripMenuItem()
        Me.GB_Encrypt = New System.Windows.Forms.GroupBox()
        Me.cmd_test = New System.Windows.Forms.Button()
        Me.cmd_make = New System.Windows.Forms.Button()
        Me.Tab4 = New System.Windows.Forms.TabPage()
        Me.OpenFileDialogs = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialogs = New System.Windows.Forms.SaveFileDialog()
        Me.TabControls.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.Grmd5en.SuspendLayout()
        Me.Tab2.SuspendLayout()
        Me.Tab3.SuspendLayout()
        Me.GB_View.SuspendLayout()
        CType(Me.PB_map, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrips.SuspendLayout()
        Me.GB_Encrypt.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControls
        '
        Me.TabControls.Controls.Add(Me.Tab1)
        Me.TabControls.Controls.Add(Me.Tab2)
        Me.TabControls.Controls.Add(Me.Tab3)
        Me.TabControls.Controls.Add(Me.Tab4)
        Me.TabControls.Location = New System.Drawing.Point(2, 1)
        Me.TabControls.Name = "TabControls"
        Me.TabControls.SelectedIndex = 0
        Me.TabControls.Size = New System.Drawing.Size(584, 259)
        Me.TabControls.TabIndex = 0
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.cmd_xmlcompress)
        Me.Tab1.Controls.Add(Me.cmd_ongxddtencrypt)
        Me.Tab1.Controls.Add(Me.Grmd5en)
        Me.Tab1.Controls.Add(Me.cmd_swfxddtencrypt)
        Me.Tab1.Controls.Add(Me.cmd_png2encrypt)
        Me.Tab1.Controls.Add(Me.cmd_swfencrypt)
        Me.Tab1.Location = New System.Drawing.Point(4, 22)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(576, 233)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "Mã hóa"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'cmd_xmlcompress
        '
        Me.cmd_xmlcompress.Location = New System.Drawing.Point(170, 6)
        Me.cmd_xmlcompress.Name = "cmd_xmlcompress"
        Me.cmd_xmlcompress.Size = New System.Drawing.Size(150, 50)
        Me.cmd_xmlcompress.TabIndex = 5
        Me.cmd_xmlcompress.Text = "XML"
        Me.cmd_xmlcompress.UseVisualStyleBackColor = True
        '
        'cmd_ongxddtencrypt
        '
        Me.cmd_ongxddtencrypt.Location = New System.Drawing.Point(3, 174)
        Me.cmd_ongxddtencrypt.Name = "cmd_ongxddtencrypt"
        Me.cmd_ongxddtencrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_ongxddtencrypt.TabIndex = 4
        Me.cmd_ongxddtencrypt.Text = "PNG::XDDT"
        Me.cmd_ongxddtencrypt.UseVisualStyleBackColor = True
        '
        'Grmd5en
        '
        Me.Grmd5en.Controls.Add(Me.cmd_gethash)
        Me.Grmd5en.Controls.Add(Me.txt_md5en)
        Me.Grmd5en.Location = New System.Drawing.Point(159, 118)
        Me.Grmd5en.Name = "Grmd5en"
        Me.Grmd5en.Size = New System.Drawing.Size(226, 106)
        Me.Grmd5en.TabIndex = 3
        Me.Grmd5en.TabStop = False
        Me.Grmd5en.Text = "MD5 :: XDDT"
        '
        'cmd_gethash
        '
        Me.cmd_gethash.Location = New System.Drawing.Point(8, 45)
        Me.cmd_gethash.Name = "cmd_gethash"
        Me.cmd_gethash.Size = New System.Drawing.Size(212, 43)
        Me.cmd_gethash.TabIndex = 2
        Me.cmd_gethash.Text = "Get Hash from file"
        Me.cmd_gethash.UseVisualStyleBackColor = True
        '
        'txt_md5en
        '
        Me.txt_md5en.Location = New System.Drawing.Point(8, 19)
        Me.txt_md5en.Name = "txt_md5en"
        Me.txt_md5en.Size = New System.Drawing.Size(212, 20)
        Me.txt_md5en.TabIndex = 0
        '
        'cmd_swfxddtencrypt
        '
        Me.cmd_swfxddtencrypt.Location = New System.Drawing.Point(3, 118)
        Me.cmd_swfxddtencrypt.Name = "cmd_swfxddtencrypt"
        Me.cmd_swfxddtencrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_swfxddtencrypt.TabIndex = 2
        Me.cmd_swfxddtencrypt.Text = "SWF::XDDT"
        Me.cmd_swfxddtencrypt.UseVisualStyleBackColor = True
        '
        'cmd_png2encrypt
        '
        Me.cmd_png2encrypt.Location = New System.Drawing.Point(3, 62)
        Me.cmd_png2encrypt.Name = "cmd_png2encrypt"
        Me.cmd_png2encrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_png2encrypt.TabIndex = 1
        Me.cmd_png2encrypt.Text = "PNG II"
        Me.cmd_png2encrypt.UseVisualStyleBackColor = True
        '
        'cmd_swfencrypt
        '
        Me.cmd_swfencrypt.Location = New System.Drawing.Point(3, 6)
        Me.cmd_swfencrypt.Name = "cmd_swfencrypt"
        Me.cmd_swfencrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_swfencrypt.TabIndex = 0
        Me.cmd_swfencrypt.Text = "SWF"
        Me.cmd_swfencrypt.UseVisualStyleBackColor = True
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.cmd_xmlDecompress)
        Me.Tab2.Controls.Add(Me.cmd_pngxddtdecrypt)
        Me.Tab2.Controls.Add(Me.cmd_swfxddtdecrypt)
        Me.Tab2.Controls.Add(Me.cmd_png2decrypt)
        Me.Tab2.Controls.Add(Me.cmd_swfdecrypt)
        Me.Tab2.Location = New System.Drawing.Point(4, 22)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(576, 233)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "Giải mã"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'cmd_xmlDecompress
        '
        Me.cmd_xmlDecompress.Location = New System.Drawing.Point(170, 6)
        Me.cmd_xmlDecompress.Name = "cmd_xmlDecompress"
        Me.cmd_xmlDecompress.Size = New System.Drawing.Size(150, 50)
        Me.cmd_xmlDecompress.TabIndex = 10
        Me.cmd_xmlDecompress.Text = "XML"
        Me.cmd_xmlDecompress.UseVisualStyleBackColor = True
        '
        'cmd_pngxddtdecrypt
        '
        Me.cmd_pngxddtdecrypt.Location = New System.Drawing.Point(3, 174)
        Me.cmd_pngxddtdecrypt.Name = "cmd_pngxddtdecrypt"
        Me.cmd_pngxddtdecrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_pngxddtdecrypt.TabIndex = 9
        Me.cmd_pngxddtdecrypt.Text = "PNG::XDDT"
        Me.cmd_pngxddtdecrypt.UseVisualStyleBackColor = True
        '
        'cmd_swfxddtdecrypt
        '
        Me.cmd_swfxddtdecrypt.Location = New System.Drawing.Point(3, 118)
        Me.cmd_swfxddtdecrypt.Name = "cmd_swfxddtdecrypt"
        Me.cmd_swfxddtdecrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_swfxddtdecrypt.TabIndex = 7
        Me.cmd_swfxddtdecrypt.Text = "SWF::XDDT"
        Me.cmd_swfxddtdecrypt.UseVisualStyleBackColor = True
        '
        'cmd_png2decrypt
        '
        Me.cmd_png2decrypt.Location = New System.Drawing.Point(3, 62)
        Me.cmd_png2decrypt.Name = "cmd_png2decrypt"
        Me.cmd_png2decrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_png2decrypt.TabIndex = 6
        Me.cmd_png2decrypt.Text = "PNG II"
        Me.cmd_png2decrypt.UseVisualStyleBackColor = True
        '
        'cmd_swfdecrypt
        '
        Me.cmd_swfdecrypt.Location = New System.Drawing.Point(3, 6)
        Me.cmd_swfdecrypt.Name = "cmd_swfdecrypt"
        Me.cmd_swfdecrypt.Size = New System.Drawing.Size(150, 50)
        Me.cmd_swfdecrypt.TabIndex = 5
        Me.cmd_swfdecrypt.Text = "SWF"
        Me.cmd_swfdecrypt.UseVisualStyleBackColor = True
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.GB_View)
        Me.Tab3.Controls.Add(Me.GB_Encrypt)
        Me.Tab3.Location = New System.Drawing.Point(4, 22)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab3.Size = New System.Drawing.Size(576, 233)
        Me.Tab3.TabIndex = 2
        Me.Tab3.Text = "Tạo map"
        Me.Tab3.UseVisualStyleBackColor = True
        '
        'GB_View
        '
        Me.GB_View.Controls.Add(Me.PB_map)
        Me.GB_View.Location = New System.Drawing.Point(243, 6)
        Me.GB_View.Name = "GB_View"
        Me.GB_View.Size = New System.Drawing.Size(327, 220)
        Me.GB_View.TabIndex = 1
        Me.GB_View.TabStop = False
        Me.GB_View.Text = "View map - 8bit"
        '
        'PB_map
        '
        Me.PB_map.ContextMenuStrip = Me.ContextMenuStrips
        Me.PB_map.Location = New System.Drawing.Point(6, 19)
        Me.PB_map.Name = "PB_map"
        Me.PB_map.Size = New System.Drawing.Size(315, 195)
        Me.PB_map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_map.TabIndex = 0
        Me.PB_map.TabStop = False
        '
        'ContextMenuStrips
        '
        Me.ContextMenuStrips.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.saveas})
        Me.ContextMenuStrips.Name = "ContextMenuStrips"
        Me.ContextMenuStrips.Size = New System.Drawing.Size(157, 26)
        '
        'saveas
        '
        Me.saveas.Name = "saveas"
        Me.saveas.Size = New System.Drawing.Size(156, 22)
        Me.saveas.Text = "Lưu hình ảnh ..."
        '
        'GB_Encrypt
        '
        Me.GB_Encrypt.Controls.Add(Me.cmd_test)
        Me.GB_Encrypt.Controls.Add(Me.cmd_make)
        Me.GB_Encrypt.Location = New System.Drawing.Point(6, 6)
        Me.GB_Encrypt.Name = "GB_Encrypt"
        Me.GB_Encrypt.Size = New System.Drawing.Size(231, 220)
        Me.GB_Encrypt.TabIndex = 0
        Me.GB_Encrypt.TabStop = False
        Me.GB_Encrypt.Text = "Map"
        '
        'cmd_test
        '
        Me.cmd_test.Location = New System.Drawing.Point(6, 85)
        Me.cmd_test.Name = "cmd_test"
        Me.cmd_test.Size = New System.Drawing.Size(219, 50)
        Me.cmd_test.TabIndex = 7
        Me.cmd_test.Text = "Test"
        Me.cmd_test.UseVisualStyleBackColor = True
        '
        'cmd_make
        '
        Me.cmd_make.Location = New System.Drawing.Point(6, 29)
        Me.cmd_make.Name = "cmd_make"
        Me.cmd_make.Size = New System.Drawing.Size(219, 50)
        Me.cmd_make.TabIndex = 6
        Me.cmd_make.Text = "Make"
        Me.cmd_make.UseVisualStyleBackColor = True
        '
        'Tab4
        '
        Me.Tab4.Location = New System.Drawing.Point(4, 22)
        Me.Tab4.Name = "Tab4"
        Me.Tab4.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab4.Size = New System.Drawing.Size(576, 233)
        Me.Tab4.TabIndex = 3
        Me.Tab4.Text = "Tạo Script"
        Me.Tab4.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 261)
        Me.Controls.Add(Me.TabControls)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DDTank Tool"
        Me.TabControls.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Grmd5en.ResumeLayout(False)
        Me.Grmd5en.PerformLayout()
        Me.Tab2.ResumeLayout(False)
        Me.Tab3.ResumeLayout(False)
        Me.GB_View.ResumeLayout(False)
        CType(Me.PB_map, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrips.ResumeLayout(False)
        Me.GB_Encrypt.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControls As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents cmd_swfxddtencrypt As System.Windows.Forms.Button
    Friend WithEvents cmd_png2encrypt As System.Windows.Forms.Button
    Friend WithEvents cmd_swfencrypt As System.Windows.Forms.Button
    Friend WithEvents Grmd5en As System.Windows.Forms.GroupBox
    Friend WithEvents txt_md5en As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialogs As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialogs As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmd_ongxddtencrypt As System.Windows.Forms.Button
    Friend WithEvents cmd_pngxddtdecrypt As System.Windows.Forms.Button
    Friend WithEvents cmd_swfxddtdecrypt As System.Windows.Forms.Button
    Friend WithEvents cmd_png2decrypt As System.Windows.Forms.Button
    Friend WithEvents cmd_swfdecrypt As System.Windows.Forms.Button
    Friend WithEvents cmd_xmlcompress As System.Windows.Forms.Button
    Friend WithEvents cmd_xmlDecompress As System.Windows.Forms.Button
    Friend WithEvents cmd_gethash As System.Windows.Forms.Button
    Friend WithEvents Tab3 As System.Windows.Forms.TabPage
    Friend WithEvents Tab4 As System.Windows.Forms.TabPage
    Friend WithEvents GB_Encrypt As System.Windows.Forms.GroupBox
    Friend WithEvents GB_View As System.Windows.Forms.GroupBox
    Friend WithEvents PB_map As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_make As System.Windows.Forms.Button
    Friend WithEvents cmd_test As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrips As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents saveas As System.Windows.Forms.ToolStripMenuItem

End Class

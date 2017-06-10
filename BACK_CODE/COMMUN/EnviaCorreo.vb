Imports System.Configuration
Imports System.Net.Mail
Imports System.Security
Imports System.Net
Public Class EnviaCorreo


    Private ReadOnly Property _smtpServer() As String
        Get
            Return ConfigurationManager.AppSettings("smtpServer").ToString()
        End Get
    End Property

    Private ReadOnly Property _puerto() As String
        Get
            Return ConfigurationManager.AppSettings("puerto").ToString()
        End Get
    End Property

    Private ReadOnly Property _correoFrom As String
        Get
            Return ConfigurationManager.AppSettings("correoFrom").ToString()
        End Get
    End Property

    Private ReadOnly Property _enableSsl As String
        Get
            Return ConfigurationManager.AppSettings("enableSsl").ToString()
        End Get
    End Property

    Private ReadOnly Property _Pass As String
        Get
            Return ConfigurationManager.AppSettings("pass").ToString()
        End Get
    End Property

    Private ReadOnly Property _correoTo1 As String
        Get
            Return ConfigurationManager.AppSettings("correoTo1").ToString()
        End Get
    End Property
    Private ReadOnly Property _correoTo2 As String
        Get
            Return ConfigurationManager.AppSettings("correoTo2").ToString()
        End Get
    End Property
    Private ReadOnly Property _correoTo3 As String
        Get
            Return ConfigurationManager.AppSettings("correoTo3").ToString()
        End Get
    End Property

    'Public Sub EnviaCorreo(ByVal Mensaje As String,
    '                           ByVal MailTo As String,
    '                           ByVal subject As String)
    '    Dim SmtpServer As New SmtpClient("104.43.230.198", 25)
    '    Dim Email As New MailMessage("clientes@topitup.net", MailTo, subject, Mensaje)
    '    SmtpServer.Send(Email)
    'End Sub

    Public Sub EnviaCorreo(ByVal Mensaje As String,
                               ByVal subject As String, blnIsSupport As Boolean)

        Try
            Dim smptServer = _smtpServer
            Dim puerto = _puerto
            Dim correoFrom = _correoFrom
            Dim enablessl = Convert.ToBoolean(_enableSsl)

            Using _smptclient As New SmtpClient(smptServer, puerto)

                Dim mailFrom = New MailAddress(correoFrom)
                Dim mailmsg = New MailMessage()
                mailmsg.From = mailFrom
                mailmsg.IsBodyHtml = True

                'Sólo al admin
                If blnIsSupport = True Then
                    If _correoTo1 <> String.Empty Then
                        mailmsg.To.Add(_correoTo1)
                    End If
                Else
                    If _correoTo1 <> String.Empty Then
                        mailmsg.To.Add(_correoTo1)
                    End If

                    If _correoTo2 <> String.Empty Then
                        mailmsg.To.Add(_correoTo2)
                    End If

                    If _correoTo3 <> String.Empty Then
                        mailmsg.To.Add(_correoTo3)
                    End If
                End If

                _smptclient.DeliveryMethod = SmtpDeliveryMethod.Network
                _smptclient.EnableSsl = enablessl

                mailmsg.Subject = subject
                mailmsg.Body = Mensaje

                _smptclient.Credentials = New System.Net.NetworkCredential(_correoFrom, _Pass)
                _smptclient.Send(mailmsg)

                mailmsg.Dispose()
            End Using
        Catch ex As SmtpException
            Throw ex
        End Try
    End Sub

    Public Sub EnviaCorreoIndividual(ByVal Mensaje As String,
                                     ByVal subject As String,
                                     EmailFROM As Integer,
                                     EmailTO As String,
                                     Optional blnAdjuntar As Boolean = False,
                                     Optional mailMsgAttach As MailMessage = Nothing,
                                     Optional imgadjuntar As Boolean = False)

        Try
            Dim smptServer = _smtpServer
            Dim puerto = _puerto
            Dim correoFrom As String
            Dim enablessl = Convert.ToBoolean(_enableSsl)

            'Select Case EmailFROM
            '    Case 1
            '        correoFrom = "atencion.clientes@topitup.net" ' "atencion.clientestip@gmail.com"
            '    Case 2
            '        correoFrom = "depositos@topitup.net" ' "depositostip@gmail.com" 
            '    Case Else
            '        correoFrom = "clientes@topitup.net" ' "atencion.clientestip@gmail.com" 
            'End Select

            correoFrom = _correoFrom

            Using _smptclient As New SmtpClient(smptServer, puerto)
                _smptclient.DeliveryMethod = SmtpDeliveryMethod.Network
                _smptclient.EnableSsl = enablessl
                Dim mailFrom = New MailAddress(correoFrom)


                Dim mailmsg = New MailMessage()
                mailmsg.From = mailFrom
                mailmsg.IsBodyHtml = True
                mailmsg.To.Add(EmailTO)
                mailmsg.Subject = subject
                mailmsg.Body = Mensaje

                If imgadjuntar Then
                    mailmsg.Attachments.Add(New System.Net.Mail.Attachment("C:\imagessystema\welcome.jpg"))
                End If

                If blnAdjuntar = True Then
                    mailMsgAttach.From = mailFrom
                    mailMsgAttach.IsBodyHtml = True
                    mailMsgAttach.To.Add(EmailTO)
                End If

                _smptclient.UseDefaultCredentials = True

                Dim credenciales As New NetworkCredential(correoFrom, _Pass)

                _smptclient.Credentials = credenciales
                If blnAdjuntar = True Then
                    _smptclient.Send(mailMsgAttach)
                    mailMsgAttach.Dispose()
                Else
                    _smptclient.Send(mailmsg)
                    mailmsg.Dispose()
                End If

            End Using
        Catch ex As SmtpException
            Throw ex
        End Try
    End Sub


    Public Sub EnviaCorreo(ByVal Mensaje As String,
                           ByVal subject As String,
                           ByVal correopara As String)

        Try
            Dim smptServer = _smtpServer
            Dim puerto = _puerto
            Dim correoFrom = _correoFrom
            Dim enablessl = Convert.ToBoolean(_enableSsl)

            Using _smptclient As New SmtpClient(smptServer, puerto)
                _smptclient.DeliveryMethod = SmtpDeliveryMethod.Network
                _smptclient.EnableSsl = enablessl
                Dim mailFrom = New MailAddress(correoFrom)
                Dim mailmsg = New MailMessage()
                mailmsg.From = mailFrom
                mailmsg.IsBodyHtml = True

                mailmsg.To.Add(correopara)

                mailmsg.Subject = subject
                mailmsg.Body = Mensaje
                _smptclient.UseDefaultCredentials = True

                Dim credenciales As New NetworkCredential(_correoFrom, _Pass)

                _smptclient.Credentials = credenciales
                _smptclient.Send(mailmsg)
                mailmsg.Dispose()
            End Using
        Catch ex As SmtpException
            Throw ex
        End Try
    End Sub

End Class

Public Class clsGenerics

    Public Function func_GetUsrConnected(vpIntPkUser As Integer) As USERS
        Dim MODEL As New EDM_TopItUp
        Dim objUser As New USERS

        objUser = MODEL.USERS.Find(vpIntPkUser)

        Return objUser
    End Function

    Public Function func_ExisteUserName(strUsername As String) As Boolean
        Dim blnExisteUsername As Boolean = False
        Dim objModel As New EDM_TopItUp
        Dim usr As New USERS

        usr = objModel.USERS.SqlQuery("SELECT * FROM USERS WHERE USERNAME='" & strUsername & "' and status in ('0','1')")(0)

        If usr Is Nothing Then
            blnExisteUsername = False
        Else
            blnExisteUsername = True
        End If

        Return blnExisteUsername
    End Function

    Public Function func_ExisteUserNameEliminado(strUsername As String) As Boolean
        Dim blnExisteUsername As Boolean = False
        Dim objModel As New EDM_TopItUp
        Dim usr As New USERS

        usr = objModel.USERS.SqlQuery("SELECT * FROM USERS WHERE USERNAME='" & strUsername & "' and status in ('2')")(0)

        If usr Is Nothing Then
            blnExisteUsername = False
        Else
            blnExisteUsername = True
        End If

        Return blnExisteUsername
    End Function
    Public Function func_GetSaldoUsr(vpIntPkUser As Integer)
        Dim vgObjModelo As New EDM_TopItUp
        Dim decSaldo As Decimal = 0.0
        Dim objUser As New USERS

        Try
            objUser = vgObjModelo.USERS.Find(vpIntPkUser)
            'decSaldo = vgObjModelo.SALDOS.SqlQuery("select * from saldos s where pk_saldo = (select max(pk_saldo) from saldos where FK_USER = " & objUser.PK_USER & " and monto_mvto> 0)").ToList()(0).SALDO()
            decSaldo = vgObjModelo.SALDOS.SqlQuery("select * from saldos s where pk_saldo = (select max(pk_saldo) from saldos where FK_USER = " & objUser.PK_USER & ")").ToList()(0).SALDO()
        Catch ex As Exception
        End Try

        Return decSaldo
    End Function

    Public Function func_GetSaldoInicialUsr(vpIntPkUser As Integer)
        Dim vgObjModelo As New EDM_TopItUp
        Dim decSaldo As Decimal = 0.0
        Dim objUser As New USERS

        objUser = vgObjModelo.USERS.Find(vpIntPkUser)
        Dim decMontoSaldo As Decimal = 0.0
        Dim intDiaNextBusqueda As Integer = 0
        Dim blnTieneSaldos As Boolean

        If vgObjModelo.SALDOS.SqlQuery("select * from saldos where fk_user =" & objUser.PK_USER).ToList().Count > 0 Then
            blnTieneSaldos = True
        Else
            blnTieneSaldos = False
        End If

        If blnTieneSaldos = True Then
            Do While decMontoSaldo = 0.0
                Try
                    decSaldo = vgObjModelo.SALDOS.SqlQuery("select saldo from saldos where fecha_mvto = dateadd(day, " & intDiaNextBusqueda & " , getdate()) and fk_user =" & objUser.PK_USER).ToList()(0).SALDO()
                Catch ex As Exception
                    decSaldo = 0.0
                End Try
                decMontoSaldo = decSaldo
                If decMontoSaldo = 0.0 Then
                    intDiaNextBusqueda -= 1
                End If
            Loop
        Else
            decSaldo = 0.0
        End If

        Return decSaldo
    End Function

    Public Function func_GetSaldoGlobal(Optional blnGetMinimoDelDia As Boolean = False) As Decimal
        Dim vgObjModelo As New EDM_TopItUp
        Dim decSaldo As Decimal = 0.0
        Dim objUser As New USERS

        Try
            For Each usr As USERS In vgObjModelo.USERS.ToList()
                If blnGetMinimoDelDia = True Then
                    decSaldo += func_GetSaldoInicialUsr(usr.PK_USER)
                Else
                    decSaldo += func_GetSaldoUsr(usr.PK_USER)
                End If
            Next

        Catch ex As Exception

        End Try

        Return decSaldo
    End Function
    Public Function func_GetUserByCliente(ByVal pkCliente As Integer) As Integer
        Dim vlObjModelo As New EDM_TopItUp
        Dim intPkUser As Integer = vlObjModelo.CLIENTES_USERS.SqlQuery("SELECT * FROM CLIENTES_USERS WHERE FK_CLIENTE=" & pkCliente).ToList()(0).FK_USER()
        Return intPkUser
    End Function

    Public Function func_GetClienteByUser(vpObjUserConnected As USERS) As Integer
        Dim vlObjModelo As New EDM_TopItUp
        Dim intPkCliente As Integer = vlObjModelo.CLIENTES_USERS.SqlQuery("SELECT * FROM CLIENTES_USERS WHERE FK_USER=" & vpObjUserConnected.PK_USER).ToList()(0).FK_CLIENTE

        Return intPkCliente
    End Function

    Public Function func_GetPorcenComisionUsrConnected(ByVal vpIntPkTelefonia As Integer, vpObjUserConnected As USERS) As Decimal
        Dim vlObjModelo As New EDM_TopItUp
        Dim blnDecPorComision As Decimal = 0.0

        blnDecPorComision = vlObjModelo.TELEFONIAS_CLIENTES.SqlQuery("Select * from TELEFONIAS_CLIENTES WHERE FK_CAT_TELEFONIA=" & vpIntPkTelefonia & " AND FK_CLIENTE=" & func_GetClienteByUser(vpObjUserConnected)).ToList()(0).COMISION_TEL_CTE

        Return blnDecPorComision
    End Function

    Public Function func_GetComisionPorTransaccion(ByVal FK_Telefonia As Integer, ByVal MontoTransaccion As Integer, vpObjUserConnected As USERS) As Decimal
        Dim vlDecMontoComision As Decimal = 0.0
        Dim vlPorcComision As Decimal = 0.0

        'Obtengo el monto de la comisión para el usuario conectado y la compañía seleccionada
        vlPorcComision = func_GetPorcenComisionUsrConnected(FK_Telefonia, vpObjUserConnected)
        vlDecMontoComision = (vlPorcComision * MontoTransaccion) / 100

        Return vlDecMontoComision
    End Function

End Class

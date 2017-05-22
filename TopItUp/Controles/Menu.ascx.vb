Public Class Menu
    Inherits System.Web.UI.UserControl

    Dim vgObjModelo As New EDM_TopItUp
    Private Property propVgBlOnlyTelcel As Boolean
        Set(value As Boolean)
            Session("propVgBlOnlyTelcel") = value
        End Set
        Get
            Return CType(Session("propVgBlOnlyTelcel"), Boolean)
        End Get
    End Property
    Private Property vgPropObjUserConnected As USERS
        Set(value As USERS)
            Session("USR") = value
        End Set
        Get
            Return Session("USR")
        End Get
    End Property

    Private Property vgPropObjCteConnected As CLIENTES
        Set(value As CLIENTES)
            Session("CTE") = value
        End Set
        Get
            Return Session("CTE")
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Me.vgPropObjUserConnected.PK_USER = -1 Then
                Session("ERROR") = "SIN PRIVILEGIOS, FAVOR DE INGRESAR SUS DATOS DE ACCESO"
                Response.Redirect("../Default.aspx")
            End If
        Catch ex As Exception
            Session("ERROR") = "SIN PRIVILEGIOS, FAVOR DE INGRESAR SUS DATOS DE ACCESO"
            Response.Redirect("../Default.aspx")
        End Try

        Dim clsGeneric As New clsGenerics
        Dim stringTable As New StringBuilder()
        stringTable.Append("GeneraMenu(" + Chr(34))

        Try
            Dim shkdga As Integer = Me.vgPropObjUserConnected.FK_ACCESS_GROUP
            Dim roles = From cust In vgObjModelo.PAGES_ACCESS_GROUPS Where _
            cust.FK_ACCESS_GROUP = vgPropObjUserConnected.FK_ACCESS_GROUP

            ' stringTable.Append("<table background='../Images/backmenu.jpg'>")
            Dim blnMostrarOpcionServ As Boolean = True
            Dim blnMostrarCompraAire As Boolean = True
            Dim strQueryTelefonias As String = "SELECT T.* FROM CAT_TELEFONIAS T, TELEFONIAS_CLIENTES TC, CLIENTES C WHERE C.PK_CLIENTE = TC.FK_CLIENTE AND T.PK_CAT_TELEFONIA = TC.FK_CAT_TELEFONIA AND TC.FK_CLIENTE=" & vgPropObjCteConnected.PK_CLIENTE
            Dim strQueryServicios As String = "SELECT S.* FROM CAT_SERVICIOS S, SERVICIOS_CLIENTE_REL R WHERE R.FK_SERVICIO = S.PK_CAT_SERVICIO AND R.FK_CLIENTE =" & vgPropObjCteConnected.PK_CLIENTE

            For Each acces In roles
                Dim pagesC As TopItUp.PAGES = vgObjModelo.PAGES.Find(acces.FK_PAGE)

                'En caso de no tener recargas telefónicas o servicios no se muestra esa página

                'pk_page 76 = compra de tiempo aire
                If pagesC.PK_PAGE = 76 Then
                    'Verifico si el usuario tiene al menos una compañía habilitada permitida
                    Dim objtelefonias As New TELEFONIAS_CLIENTES
                    If vgObjModelo.CAT_TELEFONIAS.SqlQuery(strQueryTelefonias).Count = 0 Then
                        'EN CASO DE NO TENER COMPAÑÍAS NO SE MUESTRA LA OPCIÓN DE MENÚ
                        blnMostrarCompraAire = False
                    End If
                End If

                'pk_page 77 = pago de servicios
                If pagesC.PK_PAGE = 77 Then
                    'Verifico si el usuario tiene pago de servicios permitidos
                    'EN CASO DE NO TENER PAGO DE SERVICIOS NO SE MUESTRA LA OPCIÓN DE MENÚ
                    If vgObjModelo.CAT_SERVICIOS.SqlQuery(strQueryServicios).Count = 0 Then
                        'EN CASO DE NO TENER COMPAÑÍAS NO SE MUESTRA LA OPCIÓN DE MENÚ
                        blnMostrarOpcionServ = False
                    End If
                End If

                'Si tiene la página de pago de servicio
                ' pero no tiene acceso entonces
                ' no se muestra la opción de menú
                If pagesC.PK_PAGE = 76 And blnMostrarCompraAire = True Then
                    stringTable.Append("<tr>")
                    stringTable.Append("<td class='auto-style149'>&nbsp;</td><td>")
                    stringTable.Append("<img id='Img1' runat='server' src='../Images/puntoOff.png' class='auto-style131' /><span class='auto-style131'> </td>")
                    stringTable.Append("<td><a id='opc1' runat='server' href='" + pagesC.URL + "'><span class='auto-style131'>" + pagesC.NOMBRE_CORTO + "</span></a></td>")
                    stringTable.Append("</tr>")
                End If

                If pagesC.PK_PAGE = 77 And blnMostrarOpcionServ = True Then
                    stringTable.Append("<tr>")
                    stringTable.Append("<td class='auto-style149'>&nbsp;</td><td>")
                    stringTable.Append("<img id='Img1' runat='server' src='../Images/puntoOff.png' class='auto-style131' /><span class='auto-style131'> </td>")
                    stringTable.Append("<td><a id='opc1' runat='server' href='" + pagesC.URL + "'><span class='auto-style131'>" + pagesC.NOMBRE_CORTO + "</span></a></td>")
                    stringTable.Append("</tr>")
                End If

                If pagesC.PK_PAGE <> 76 And pagesC.PK_PAGE <> 77 Then
                    stringTable.Append("<tr>")
                    stringTable.Append("<td class='auto-style149'>&nbsp;</td><td>")
                    stringTable.Append("<img id='Img1' runat='server' src='../Images/puntoOff.png' class='auto-style131' /><span class='auto-style131'> </td>")
                    stringTable.Append("<td><a id='opc1' runat='server' href='" + pagesC.URL + "'><span class='auto-style131'>" + pagesC.NOMBRE_CORTO + "</span></a></td>")
                    stringTable.Append("</tr>")
                End If

            Next

            stringTable.Append("<tr>")
            stringTable.Append("<td class='auto-style149'>")
            stringTable.Append("&nbsp;</td>")
            stringTable.Append("<td>")
            stringTable.Append("<img id='Img10' runat='server' src='../Images/puntoOff.png' class='auto-style131' /><span class='auto-style131'> </td>")

            If Me.propVgBlOnlyTelcel = True Then
                propVgBlOnlyTelcel = True
                stringTable.Append("<td><a id='opc10' runat='server' href='../Default.aspx'><span class='auto-style131'>Salir / Cerrar Sesión</span></a></td>")
            Else
                propVgBlOnlyTelcel = False
                stringTable.Append("<td><a id='opc10' runat='server' href='../Otras.aspx'><span class='auto-style131'>Salir / Cerrar Sesión</span></a></td>")
            End If

            stringTable.Append("</tr>")
            stringTable.Append("<tr><td class='auto-style130'></td><td class='auto-style130'></td>")
            stringTable.Append("</tr><tr class='auto-style131'><td>&nbsp;</td><td>&nbsp;</td></tr>")
            stringTable.Append("<tr class='auto-style131'><td>&nbsp;</td><td>&nbsp;</td></tr><tr class='auto-style131'>")
            stringTable.Append("<td>&nbsp;</td><td>&nbsp;</td></tr><tr class='auto-style131'><td>&nbsp;</td><td>&nbsp;</td>")
            stringTable.Append("</tr><tr class='auto-style131'><td>&nbsp;</td><td>&nbsp;</td></tr>")
            stringTable.Append("<tr class='auto-style131'><td>&nbsp;</td><td>&nbsp;</td></tr>")
            ' stringTable.Append("</table>")

            stringTable.Append(Chr(34) + ");")

            ScriptManager.RegisterStartupScript(Me.Page, Me.Page.[GetType](), "fcnGenerarMenu", stringTable.ToString(), True)
        Catch ex As Exception
            Response.Redirect("../Default.aspx")
        End Try
        'vgObjModelo.USERS.Where(Function(x) x.PK_USER = userID)

    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)

    End Sub
End Class
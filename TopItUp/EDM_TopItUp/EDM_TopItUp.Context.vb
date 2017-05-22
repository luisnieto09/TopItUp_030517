﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class EDM_TopItUp
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=EDM_TopItUp")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property ACCESOS() As DbSet(Of ACCESOS)
    Public Overridable Property ACCESS_GROUPS() As DbSet(Of ACCESS_GROUPS)
    Public Overridable Property CAT_BANCOS() As DbSet(Of CAT_BANCOS)
    Public Overridable Property CAT_MEDIOS_DE_PAGO() As DbSet(Of CAT_MEDIOS_DE_PAGO)
    Public Overridable Property CAT_MONEDAS() As DbSet(Of CAT_MONEDAS)
    Public Overridable Property CAT_MONTOS_DISPONIBLES() As DbSet(Of CAT_MONTOS_DISPONIBLES)
    Public Overridable Property CAT_PAISES() As DbSet(Of CAT_PAISES)
    Public Overridable Property CAT_RAZONES_SOCIALES() As DbSet(Of CAT_RAZONES_SOCIALES)
    Public Overridable Property CAT_SERVICIOS() As DbSet(Of CAT_SERVICIOS)
    Public Overridable Property CAT_STATUS_PAGOS() As DbSet(Of CAT_STATUS_PAGOS)
    Public Overridable Property CAT_TELEFONIAS() As DbSet(Of CAT_TELEFONIAS)
    Public Overridable Property CAT_TIPOS_MVTO() As DbSet(Of CAT_TIPOS_MVTO)
    Public Overridable Property CAT_WS() As DbSet(Of CAT_WS)
    Public Overridable Property CLIENTES() As DbSet(Of CLIENTES)
    Public Overridable Property CLIENTES_USERS() As DbSet(Of CLIENTES_USERS)
    Public Overridable Property CTAS_BANCARIAS_EMPRESAS() As DbSet(Of CTAS_BANCARIAS_EMPRESAS)
    Public Overridable Property DUDAS_COMENTARIOS() As DbSet(Of DUDAS_COMENTARIOS)
    Public Overridable Property EMPRESAS() As DbSet(Of EMPRESAS)
    Public Overridable Property FILES() As DbSet(Of FILES)
    Public Overridable Property LLAVES_TRANS_SODESI_PRONTIPAGOS() As DbSet(Of LLAVES_TRANS_SODESI_PRONTIPAGOS)
    Public Overridable Property NOTICIAS() As DbSet(Of NOTICIAS)
    Public Overridable Property NOTICIAS_CLIENTES() As DbSet(Of NOTICIAS_CLIENTES)
    Public Overridable Property PAGES() As DbSet(Of PAGES)
    Public Overridable Property PAGES_ACCESS_GROUPS() As DbSet(Of PAGES_ACCESS_GROUPS)
    Public Overridable Property PAGES_USERS() As DbSet(Of PAGES_USERS)
    Public Overridable Property PAGOS() As DbSet(Of PAGOS)
    Public Overridable Property PAGOS_FILES_UPLOADED() As DbSet(Of PAGOS_FILES_UPLOADED)
    Public Overridable Property PARAMETROS() As DbSet(Of PARAMETROS)
    Public Overridable Property SALDOS() As DbSet(Of SALDOS)
    Public Overridable Property SERVICIOS_CLIENTE_REL() As DbSet(Of SERVICIOS_CLIENTE_REL)
    Public Overridable Property TELEFONIAS_CLIENTES() As DbSet(Of TELEFONIAS_CLIENTES)
    Public Overridable Property TELEFONIAS_PAISES() As DbSet(Of TELEFONIAS_PAISES)
    Public Overridable Property WCF() As DbSet(Of WCF)
    Public Overridable Property REGISTRO_RAPIDO() As DbSet(Of REGISTRO_RAPIDO)
    Public Overridable Property CAJEROS() As DbSet(Of CAJEROS)
    Public Overridable Property HORARIO_CAJERO() As DbSet(Of HORARIO_CAJERO)
    Public Overridable Property TRANSACCIONES_CAJERO() As DbSet(Of TRANSACCIONES_CAJERO)
    Public Overridable Property INTEGRATICKETS() As DbSet(Of INTEGRATICKETS)
    Public Overridable Property INTEGRA_TICKETS() As DbSet(Of INTEGRA_TICKETS)
    Public Overridable Property NVOINTEGRATICKET() As DbSet(Of NVOINTEGRATICKET)
    Public Overridable Property USERS() As DbSet(Of USERS)
    Public Overridable Property TRANSACCIONES() As DbSet(Of TRANSACCIONES)
    Public Overridable Property CAT_MOSTRAR_HASTA() As DbSet(Of CAT_MOSTRAR_HASTA)
    Public Overridable Property sysdiagrams() As DbSet(Of sysdiagrams)
    Public Overridable Property WCF_USEREXTERNALCODE() As DbSet(Of WCF_USEREXTERNALCODE)
    Public Overridable Property WCF_USERTRANSACTIONS() As DbSet(Of WCF_USERTRANSACTIONS)
    Public Overridable Property WCF_USERTRANSACTIONSS() As DbSet(Of WCF_USERTRANSACTIONSS)
    Public Overridable Property WSF_USERTRANSACTIONS() As DbSet(Of WSF_USERTRANSACTIONS)
    Public Overridable Property TiempoAireTransact() As DbSet(Of TiempoAireTransact)

    Public Overridable Function Get_Noticias_Usuario(pk_User As Nullable(Of Integer), fecha_inicio As Nullable(Of Date), fecha_fin As Nullable(Of Date)) As ObjectResult(Of Get_Noticias_Usuario_Result)
        Dim pk_UserParameter As ObjectParameter = If(pk_User.HasValue, New ObjectParameter("Pk_User", pk_User), New ObjectParameter("Pk_User", GetType(Integer)))

        Dim fecha_inicioParameter As ObjectParameter = If(fecha_inicio.HasValue, New ObjectParameter("fecha_inicio", fecha_inicio), New ObjectParameter("fecha_inicio", GetType(Date)))

        Dim fecha_finParameter As ObjectParameter = If(fecha_fin.HasValue, New ObjectParameter("fecha_fin", fecha_fin), New ObjectParameter("fecha_fin", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Get_Noticias_Usuario_Result)("Get_Noticias_Usuario", pk_UserParameter, fecha_inicioParameter, fecha_finParameter)
    End Function

    Public Overridable Function Get_TransServiceByUSer(vpPkUserConnected As Nullable(Of Integer)) As ObjectResult(Of Get_TransServiceByUSer_Result)
        Dim vpPkUserConnectedParameter As ObjectParameter = If(vpPkUserConnected.HasValue, New ObjectParameter("vpPkUserConnected", vpPkUserConnected), New ObjectParameter("vpPkUserConnected", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Get_TransServiceByUSer_Result)("Get_TransServiceByUSer", vpPkUserConnectedParameter)
    End Function

    Public Overridable Function sp_get_Depositos_Recibidos(fechaInicio As Nullable(Of Date), fechaFin As Nullable(Of Date), pK_USER As Nullable(Of Integer), pK_BANCO As Nullable(Of Integer)) As ObjectResult(Of sp_get_Depositos_Recibidos_Result)
        Dim fechaInicioParameter As ObjectParameter = If(fechaInicio.HasValue, New ObjectParameter("FechaInicio", fechaInicio), New ObjectParameter("FechaInicio", GetType(Date)))

        Dim fechaFinParameter As ObjectParameter = If(fechaFin.HasValue, New ObjectParameter("FechaFin", fechaFin), New ObjectParameter("FechaFin", GetType(Date)))

        Dim pK_USERParameter As ObjectParameter = If(pK_USER.HasValue, New ObjectParameter("PK_USER", pK_USER), New ObjectParameter("PK_USER", GetType(Integer)))

        Dim pK_BANCOParameter As ObjectParameter = If(pK_BANCO.HasValue, New ObjectParameter("PK_BANCO", pK_BANCO), New ObjectParameter("PK_BANCO", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_Depositos_Recibidos_Result)("sp_get_Depositos_Recibidos", fechaInicioParameter, fechaFinParameter, pK_USERParameter, pK_BANCOParameter)
    End Function

    Public Overridable Function sp_get_MvtosTiempoAire(vpPkUserConnected As Nullable(Of Integer), intSoloTelcel As Nullable(Of Integer)) As ObjectResult(Of sp_get_MvtosTiempoAire_Result)
        Dim vpPkUserConnectedParameter As ObjectParameter = If(vpPkUserConnected.HasValue, New ObjectParameter("vpPkUserConnected", vpPkUserConnected), New ObjectParameter("vpPkUserConnected", GetType(Integer)))

        Dim intSoloTelcelParameter As ObjectParameter = If(intSoloTelcel.HasValue, New ObjectParameter("intSoloTelcel", intSoloTelcel), New ObjectParameter("intSoloTelcel", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_MvtosTiempoAire_Result)("sp_get_MvtosTiempoAire", vpPkUserConnectedParameter, intSoloTelcelParameter)
    End Function

    Public Overridable Function sp_get_Noticias(fK_Cliente As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim fK_ClienteParameter As ObjectParameter = If(fK_Cliente.HasValue, New ObjectParameter("FK_Cliente", fK_Cliente), New ObjectParameter("FK_Cliente", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("sp_get_Noticias", fK_ClienteParameter)
    End Function

    Public Overridable Function sp_get_Traspasos_Otros_Cargos(fechaInicio As Nullable(Of Date), fechaFin As Nullable(Of Date), pK_USER As Nullable(Of Integer)) As ObjectResult(Of sp_get_Traspasos_Otros_Cargos_Result)
        Dim fechaInicioParameter As ObjectParameter = If(fechaInicio.HasValue, New ObjectParameter("FechaInicio", fechaInicio), New ObjectParameter("FechaInicio", GetType(Date)))

        Dim fechaFinParameter As ObjectParameter = If(fechaFin.HasValue, New ObjectParameter("FechaFin", fechaFin), New ObjectParameter("FechaFin", GetType(Date)))

        Dim pK_USERParameter As ObjectParameter = If(pK_USER.HasValue, New ObjectParameter("PK_USER", pK_USER), New ObjectParameter("PK_USER", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_Traspasos_Otros_Cargos_Result)("sp_get_Traspasos_Otros_Cargos", fechaInicioParameter, fechaFinParameter, pK_USERParameter)
    End Function

    Public Overridable Function sp_get_UltimosMvtosTodosLosCtes(intSoloTelcel As Nullable(Of Integer)) As ObjectResult(Of sp_get_UltimosMvtosTodosLosCtes_Result)
        Dim intSoloTelcelParameter As ObjectParameter = If(intSoloTelcel.HasValue, New ObjectParameter("intSoloTelcel", intSoloTelcel), New ObjectParameter("intSoloTelcel", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_UltimosMvtosTodosLosCtes_Result)("sp_get_UltimosMvtosTodosLosCtes", intSoloTelcelParameter)
    End Function

    Public Overridable Function sp_get_Ventas_clientes(fechaInicio As Nullable(Of Date), fechaFin As Nullable(Of Date), pK_USER As Nullable(Of Integer), pK_CLIENTE As Nullable(Of Integer)) As ObjectResult(Of sp_get_Ventas_clientes_Result)
        Dim fechaInicioParameter As ObjectParameter = If(fechaInicio.HasValue, New ObjectParameter("FechaInicio", fechaInicio), New ObjectParameter("FechaInicio", GetType(Date)))

        Dim fechaFinParameter As ObjectParameter = If(fechaFin.HasValue, New ObjectParameter("FechaFin", fechaFin), New ObjectParameter("FechaFin", GetType(Date)))

        Dim pK_USERParameter As ObjectParameter = If(pK_USER.HasValue, New ObjectParameter("PK_USER", pK_USER), New ObjectParameter("PK_USER", GetType(Integer)))

        Dim pK_CLIENTEParameter As ObjectParameter = If(pK_CLIENTE.HasValue, New ObjectParameter("PK_CLIENTE", pK_CLIENTE), New ObjectParameter("PK_CLIENTE", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_Ventas_clientes_Result)("sp_get_Ventas_clientes", fechaInicioParameter, fechaFinParameter, pK_USERParameter, pK_CLIENTEParameter)
    End Function

    Public Overridable Function sp_get_Ventas_compañia(fechaInicio As Nullable(Of Date), fechaFin As Nullable(Of Date), pK_USER As Nullable(Of Integer)) As ObjectResult(Of sp_get_Ventas_compañia_Result)
        Dim fechaInicioParameter As ObjectParameter = If(fechaInicio.HasValue, New ObjectParameter("FechaInicio", fechaInicio), New ObjectParameter("FechaInicio", GetType(Date)))

        Dim fechaFinParameter As ObjectParameter = If(fechaFin.HasValue, New ObjectParameter("FechaFin", fechaFin), New ObjectParameter("FechaFin", GetType(Date)))

        Dim pK_USERParameter As ObjectParameter = If(pK_USER.HasValue, New ObjectParameter("PK_USER", pK_USER), New ObjectParameter("PK_USER", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_Ventas_compañia_Result)("sp_get_Ventas_compañia", fechaInicioParameter, fechaFinParameter, pK_USERParameter)
    End Function

    Public Overridable Function sp_get_Ventas_Hora(fechaInicio As Nullable(Of Date), fechaFin As Nullable(Of Date), pK_USER As Nullable(Of Integer)) As ObjectResult(Of sp_get_Ventas_Hora_Result)
        Dim fechaInicioParameter As ObjectParameter = If(fechaInicio.HasValue, New ObjectParameter("FechaInicio", fechaInicio), New ObjectParameter("FechaInicio", GetType(Date)))

        Dim fechaFinParameter As ObjectParameter = If(fechaFin.HasValue, New ObjectParameter("FechaFin", fechaFin), New ObjectParameter("FechaFin", GetType(Date)))

        Dim pK_USERParameter As ObjectParameter = If(pK_USER.HasValue, New ObjectParameter("PK_USER", pK_USER), New ObjectParameter("PK_USER", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_Ventas_Hora_Result)("sp_get_Ventas_Hora", fechaInicioParameter, fechaFinParameter, pK_USERParameter)
    End Function

    Public Overridable Function sp_GetDepositos(pk_user As Nullable(Of Integer)) As ObjectResult(Of sp_GetDepositos_Result)
        Dim pk_userParameter As ObjectParameter = If(pk_user.HasValue, New ObjectParameter("pk_user", pk_user), New ObjectParameter("pk_user", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetDepositos_Result)("sp_GetDepositos", pk_userParameter)
    End Function

    Public Overridable Function sp_GetEdoCtaByPkUser(pK_USER As Nullable(Of Integer), fECHA_INI As Nullable(Of Date), fECHA_FIN As Nullable(Of Date)) As ObjectResult(Of sp_GetEdoCtaByPkUser_Result)
        Dim pK_USERParameter As ObjectParameter = If(pK_USER.HasValue, New ObjectParameter("PK_USER", pK_USER), New ObjectParameter("PK_USER", GetType(Integer)))

        Dim fECHA_INIParameter As ObjectParameter = If(fECHA_INI.HasValue, New ObjectParameter("FECHA_INI", fECHA_INI), New ObjectParameter("FECHA_INI", GetType(Date)))

        Dim fECHA_FINParameter As ObjectParameter = If(fECHA_FIN.HasValue, New ObjectParameter("FECHA_FIN", fECHA_FIN), New ObjectParameter("FECHA_FIN", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetEdoCtaByPkUser_Result)("sp_GetEdoCtaByPkUser", pK_USERParameter, fECHA_INIParameter, fECHA_FINParameter)
    End Function

    Public Overridable Function sp_GetListaClientes(pk_user As Nullable(Of Integer), pk_cliente As Nullable(Of Integer)) As ObjectResult(Of sp_GetListaClientes_Result)
        Dim pk_userParameter As ObjectParameter = If(pk_user.HasValue, New ObjectParameter("pk_user", pk_user), New ObjectParameter("pk_user", GetType(Integer)))

        Dim pk_clienteParameter As ObjectParameter = If(pk_cliente.HasValue, New ObjectParameter("pk_cliente", pk_cliente), New ObjectParameter("pk_cliente", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_GetListaClientes_Result)("sp_GetListaClientes", pk_userParameter, pk_clienteParameter)
    End Function

    Public Overridable Function sp_get_Anuncio(fK_Cliente As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim fK_ClienteParameter As ObjectParameter = If(fK_Cliente.HasValue, New ObjectParameter("FK_Cliente", fK_Cliente), New ObjectParameter("FK_Cliente", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("sp_get_Anuncio", fK_ClienteParameter)
    End Function

    Public Overridable Function ObtieneColumnasTabla_SP(nombreTabla As String) As ObjectResult(Of ObtieneColumnasTabla_SP_Result)
        Dim nombreTablaParameter As ObjectParameter = If(nombreTabla IsNot Nothing, New ObjectParameter("NombreTabla", nombreTabla), New ObjectParameter("NombreTabla", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of ObtieneColumnasTabla_SP_Result)("ObtieneColumnasTabla_SP", nombreTablaParameter)
    End Function

    Public Overridable Function ObtieneTablas_SP() As ObjectResult(Of String)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("ObtieneTablas_SP")
    End Function

    Public Overridable Function SALDOS_SP(vOPCION As Nullable(Of Integer), vPK_SALDO As Nullable(Of Integer), vFK_USER As Nullable(Of Integer), vFK_TRANSACCION As Nullable(Of Integer), vFK_PAGO As Nullable(Of Integer), vMONTO_MVTO As Nullable(Of Decimal), vMONTO_PAGO As Nullable(Of Decimal), vSALDO As Nullable(Of Decimal), vFECHA_MVTO As Nullable(Of Date)) As ObjectResult(Of Nullable(Of Integer))
        Dim vOPCIONParameter As ObjectParameter = If(vOPCION.HasValue, New ObjectParameter("VOPCION", vOPCION), New ObjectParameter("VOPCION", GetType(Integer)))

        Dim vPK_SALDOParameter As ObjectParameter = If(vPK_SALDO.HasValue, New ObjectParameter("VPK_SALDO", vPK_SALDO), New ObjectParameter("VPK_SALDO", GetType(Integer)))

        Dim vFK_USERParameter As ObjectParameter = If(vFK_USER.HasValue, New ObjectParameter("VFK_USER", vFK_USER), New ObjectParameter("VFK_USER", GetType(Integer)))

        Dim vFK_TRANSACCIONParameter As ObjectParameter = If(vFK_TRANSACCION.HasValue, New ObjectParameter("VFK_TRANSACCION", vFK_TRANSACCION), New ObjectParameter("VFK_TRANSACCION", GetType(Integer)))

        Dim vFK_PAGOParameter As ObjectParameter = If(vFK_PAGO.HasValue, New ObjectParameter("VFK_PAGO", vFK_PAGO), New ObjectParameter("VFK_PAGO", GetType(Integer)))

        Dim vMONTO_MVTOParameter As ObjectParameter = If(vMONTO_MVTO.HasValue, New ObjectParameter("VMONTO_MVTO", vMONTO_MVTO), New ObjectParameter("VMONTO_MVTO", GetType(Decimal)))

        Dim vMONTO_PAGOParameter As ObjectParameter = If(vMONTO_PAGO.HasValue, New ObjectParameter("VMONTO_PAGO", vMONTO_PAGO), New ObjectParameter("VMONTO_PAGO", GetType(Decimal)))

        Dim vSALDOParameter As ObjectParameter = If(vSALDO.HasValue, New ObjectParameter("VSALDO", vSALDO), New ObjectParameter("VSALDO", GetType(Decimal)))

        Dim vFECHA_MVTOParameter As ObjectParameter = If(vFECHA_MVTO.HasValue, New ObjectParameter("VFECHA_MVTO", vFECHA_MVTO), New ObjectParameter("VFECHA_MVTO", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("SALDOS_SP", vOPCIONParameter, vPK_SALDOParameter, vFK_USERParameter, vFK_TRANSACCIONParameter, vFK_PAGOParameter, vMONTO_MVTOParameter, vMONTO_PAGOParameter, vSALDOParameter, vFECHA_MVTOParameter)
    End Function

    Public Overridable Function TRANSACCIONES_SP(vOPCION As Nullable(Of Integer), vPK_TRANSACCION As Nullable(Of Integer), vFK_USER As Nullable(Of Integer), vFK_CAT_TIPO_MVTO As Nullable(Of Integer), vFK_CAT_TELEFONIA As Nullable(Of Integer), vFK_CAT_SERVICIO As Nullable(Of Integer), vFK_CAT_MEDIO_DE_PAGO As Nullable(Of Integer), vFECHA As Nullable(Of Date), vHORA As String, vNUMERO_RECARGA As String, vMONTO_MTO As Nullable(Of Decimal), vFOLIO As String, vTRANSACCION As String, vFK_CAT_WS As Nullable(Of Integer), vMOTIVO_TRASPASO As String) As ObjectResult(Of Nullable(Of Integer))
        Dim vOPCIONParameter As ObjectParameter = If(vOPCION.HasValue, New ObjectParameter("VOPCION", vOPCION), New ObjectParameter("VOPCION", GetType(Integer)))

        Dim vPK_TRANSACCIONParameter As ObjectParameter = If(vPK_TRANSACCION.HasValue, New ObjectParameter("VPK_TRANSACCION", vPK_TRANSACCION), New ObjectParameter("VPK_TRANSACCION", GetType(Integer)))

        Dim vFK_USERParameter As ObjectParameter = If(vFK_USER.HasValue, New ObjectParameter("VFK_USER", vFK_USER), New ObjectParameter("VFK_USER", GetType(Integer)))

        Dim vFK_CAT_TIPO_MVTOParameter As ObjectParameter = If(vFK_CAT_TIPO_MVTO.HasValue, New ObjectParameter("VFK_CAT_TIPO_MVTO", vFK_CAT_TIPO_MVTO), New ObjectParameter("VFK_CAT_TIPO_MVTO", GetType(Integer)))

        Dim vFK_CAT_TELEFONIAParameter As ObjectParameter = If(vFK_CAT_TELEFONIA.HasValue, New ObjectParameter("VFK_CAT_TELEFONIA", vFK_CAT_TELEFONIA), New ObjectParameter("VFK_CAT_TELEFONIA", GetType(Integer)))

        Dim vFK_CAT_SERVICIOParameter As ObjectParameter = If(vFK_CAT_SERVICIO.HasValue, New ObjectParameter("VFK_CAT_SERVICIO", vFK_CAT_SERVICIO), New ObjectParameter("VFK_CAT_SERVICIO", GetType(Integer)))

        Dim vFK_CAT_MEDIO_DE_PAGOParameter As ObjectParameter = If(vFK_CAT_MEDIO_DE_PAGO.HasValue, New ObjectParameter("VFK_CAT_MEDIO_DE_PAGO", vFK_CAT_MEDIO_DE_PAGO), New ObjectParameter("VFK_CAT_MEDIO_DE_PAGO", GetType(Integer)))

        Dim vFECHAParameter As ObjectParameter = If(vFECHA.HasValue, New ObjectParameter("VFECHA", vFECHA), New ObjectParameter("VFECHA", GetType(Date)))

        Dim vHORAParameter As ObjectParameter = If(vHORA IsNot Nothing, New ObjectParameter("VHORA", vHORA), New ObjectParameter("VHORA", GetType(String)))

        Dim vNUMERO_RECARGAParameter As ObjectParameter = If(vNUMERO_RECARGA IsNot Nothing, New ObjectParameter("VNUMERO_RECARGA", vNUMERO_RECARGA), New ObjectParameter("VNUMERO_RECARGA", GetType(String)))

        Dim vMONTO_MTOParameter As ObjectParameter = If(vMONTO_MTO.HasValue, New ObjectParameter("VMONTO_MTO", vMONTO_MTO), New ObjectParameter("VMONTO_MTO", GetType(Decimal)))

        Dim vFOLIOParameter As ObjectParameter = If(vFOLIO IsNot Nothing, New ObjectParameter("VFOLIO", vFOLIO), New ObjectParameter("VFOLIO", GetType(String)))

        Dim vTRANSACCIONParameter As ObjectParameter = If(vTRANSACCION IsNot Nothing, New ObjectParameter("VTRANSACCION", vTRANSACCION), New ObjectParameter("VTRANSACCION", GetType(String)))

        Dim vFK_CAT_WSParameter As ObjectParameter = If(vFK_CAT_WS.HasValue, New ObjectParameter("VFK_CAT_WS", vFK_CAT_WS), New ObjectParameter("VFK_CAT_WS", GetType(Integer)))

        Dim vMOTIVO_TRASPASOParameter As ObjectParameter = If(vMOTIVO_TRASPASO IsNot Nothing, New ObjectParameter("VMOTIVO_TRASPASO", vMOTIVO_TRASPASO), New ObjectParameter("VMOTIVO_TRASPASO", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("TRANSACCIONES_SP", vOPCIONParameter, vPK_TRANSACCIONParameter, vFK_USERParameter, vFK_CAT_TIPO_MVTOParameter, vFK_CAT_TELEFONIAParameter, vFK_CAT_SERVICIOParameter, vFK_CAT_MEDIO_DE_PAGOParameter, vFECHAParameter, vHORAParameter, vNUMERO_RECARGAParameter, vMONTO_MTOParameter, vFOLIOParameter, vTRANSACCIONParameter, vFK_CAT_WSParameter, vMOTIVO_TRASPASOParameter)
    End Function

    Public Overridable Function sp_get_cat_mostrar_hasta() As ObjectResult(Of sp_get_cat_mostrar_hasta_Result)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of sp_get_cat_mostrar_hasta_Result)("sp_get_cat_mostrar_hasta")
    End Function

    Public Overridable Function COMISIONES_SP(vUSER As Nullable(Of Integer), vFECHAINICIO As Nullable(Of Date), vFECHAFIN As Nullable(Of Date)) As ObjectResult(Of COMISIONES_SP_Result)
        Dim vUSERParameter As ObjectParameter = If(vUSER.HasValue, New ObjectParameter("VUSER", vUSER), New ObjectParameter("VUSER", GetType(Integer)))

        Dim vFECHAINICIOParameter As ObjectParameter = If(vFECHAINICIO.HasValue, New ObjectParameter("VFECHAINICIO", vFECHAINICIO), New ObjectParameter("VFECHAINICIO", GetType(Date)))

        Dim vFECHAFINParameter As ObjectParameter = If(vFECHAFIN.HasValue, New ObjectParameter("VFECHAFIN", vFECHAFIN), New ObjectParameter("VFECHAFIN", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of COMISIONES_SP_Result)("COMISIONES_SP", vUSERParameter, vFECHAINICIOParameter, vFECHAFINParameter)
    End Function

    Public Overridable Function sp_alterdiagram(diagramname As String, owner_id As Nullable(Of Integer), version As Nullable(Of Integer), definition As Byte()) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Dim versionParameter As ObjectParameter = If(version.HasValue, New ObjectParameter("version", version), New ObjectParameter("version", GetType(Integer)))

        Dim definitionParameter As ObjectParameter = If(definition IsNot Nothing, New ObjectParameter("definition", definition), New ObjectParameter("definition", GetType(Byte())))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter)
    End Function

    Public Overridable Function sp_creatediagram(diagramname As String, owner_id As Nullable(Of Integer), version As Nullable(Of Integer), definition As Byte()) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Dim versionParameter As ObjectParameter = If(version.HasValue, New ObjectParameter("version", version), New ObjectParameter("version", GetType(Integer)))

        Dim definitionParameter As ObjectParameter = If(definition IsNot Nothing, New ObjectParameter("definition", definition), New ObjectParameter("definition", GetType(Byte())))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter)
    End Function

    Public Overridable Function sp_dropdiagram(diagramname As String, owner_id As Nullable(Of Integer)) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter)
    End Function

    Public Overridable Function sp_helpdiagramdefinition(diagramname As String, owner_id As Nullable(Of Integer)) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter)
    End Function

    Public Overridable Function sp_helpdiagrams(diagramname As String, owner_id As Nullable(Of Integer)) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter)
    End Function

    Public Overridable Function sp_renamediagram(diagramname As String, owner_id As Nullable(Of Integer), new_diagramname As String) As Integer
        Dim diagramnameParameter As ObjectParameter = If(diagramname IsNot Nothing, New ObjectParameter("diagramname", diagramname), New ObjectParameter("diagramname", GetType(String)))

        Dim owner_idParameter As ObjectParameter = If(owner_id.HasValue, New ObjectParameter("owner_id", owner_id), New ObjectParameter("owner_id", GetType(Integer)))

        Dim new_diagramnameParameter As ObjectParameter = If(new_diagramname IsNot Nothing, New ObjectParameter("new_diagramname", new_diagramname), New ObjectParameter("new_diagramname", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter)
    End Function

    Public Overridable Function sp_upgraddiagrams() As Integer
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("sp_upgraddiagrams")
    End Function

    Public Overridable Function to_sp_consultaMapeoSkuPlanes(pK_CAT_TELEFONIA As Nullable(Of Integer)) As ObjectResult(Of to_sp_consultaMapeoSkuPlanes_Result)
        Dim pK_CAT_TELEFONIAParameter As ObjectParameter = If(pK_CAT_TELEFONIA.HasValue, New ObjectParameter("PK_CAT_TELEFONIA", pK_CAT_TELEFONIA), New ObjectParameter("PK_CAT_TELEFONIA", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of to_sp_consultaMapeoSkuPlanes_Result)("to_sp_consultaMapeoSkuPlanes", pK_CAT_TELEFONIAParameter)
    End Function

    Public Overridable Function to_sp_consultaMapeoSkuServicios() As ObjectResult(Of to_sp_consultaMapeoSkuServicios_Result)
        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of to_sp_consultaMapeoSkuServicios_Result)("to_sp_consultaMapeoSkuServicios")
    End Function

    Public Overridable Function to_sp_consultaMapeoSkuTiempoAire(pK_CAT_TELEFONIA As Nullable(Of Integer)) As ObjectResult(Of to_sp_consultaMapeoSkuTiempoAire_Result)
        Dim pK_CAT_TELEFONIAParameter As ObjectParameter = If(pK_CAT_TELEFONIA.HasValue, New ObjectParameter("PK_CAT_TELEFONIA", pK_CAT_TELEFONIA), New ObjectParameter("PK_CAT_TELEFONIA", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of to_sp_consultaMapeoSkuTiempoAire_Result)("to_sp_consultaMapeoSkuTiempoAire", pK_CAT_TELEFONIAParameter)
    End Function

    Public Overridable Function tu_sp_actualizaEstatusTiempoAireTransact(id As Nullable(Of Integer)) As Integer
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("Id", id), New ObjectParameter("Id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("tu_sp_actualizaEstatusTiempoAireTransact", idParameter)
    End Function

    Public Overridable Function tu_sp_actualizaPassword(eMAIL As String, pASSWORD As String) As Integer
        Dim eMAILParameter As ObjectParameter = If(eMAIL IsNot Nothing, New ObjectParameter("EMAIL", eMAIL), New ObjectParameter("EMAIL", GetType(String)))

        Dim pASSWORDParameter As ObjectParameter = If(pASSWORD IsNot Nothing, New ObjectParameter("PASSWORD", pASSWORD), New ObjectParameter("PASSWORD", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("tu_sp_actualizaPassword", eMAILParameter, pASSWORDParameter)
    End Function

    Public Overridable Function tu_sp_actualizaStatus(eMAIL As String) As Integer
        Dim eMAILParameter As ObjectParameter = If(eMAIL IsNot Nothing, New ObjectParameter("EMAIL", eMAIL), New ObjectParameter("EMAIL", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("tu_sp_actualizaStatus", eMAILParameter)
    End Function

    Public Overridable Function tu_sp_consultaTelefonias(iSTae As Nullable(Of Boolean)) As ObjectResult(Of tu_sp_consultaTelefonias_Result)
        Dim iSTaeParameter As ObjectParameter = If(iSTae.HasValue, New ObjectParameter("iSTae", iSTae), New ObjectParameter("iSTae", GetType(Boolean)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of tu_sp_consultaTelefonias_Result)("tu_sp_consultaTelefonias", iSTaeParameter)
    End Function

    Public Overridable Function tu_sp_consultaUsuario(eMAIL As String) As ObjectResult(Of tu_sp_consultaUsuario_Result)
        Dim eMAILParameter As ObjectParameter = If(eMAIL IsNot Nothing, New ObjectParameter("EMAIL", eMAIL), New ObjectParameter("EMAIL", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of tu_sp_consultaUsuario_Result)("tu_sp_consultaUsuario", eMAILParameter)
    End Function

    Public Overridable Function tu_sp_creaUsuario(pK_USER As ObjectParameter, aP_PATERNO As String, aP_MATERNO As String, nOMBRE As String, eMAIL As String, tELEFONO As String, pASSWORD As String, cODIGO As Nullable(Of Integer)) As Integer
        Dim aP_PATERNOParameter As ObjectParameter = If(aP_PATERNO IsNot Nothing, New ObjectParameter("AP_PATERNO", aP_PATERNO), New ObjectParameter("AP_PATERNO", GetType(String)))

        Dim aP_MATERNOParameter As ObjectParameter = If(aP_MATERNO IsNot Nothing, New ObjectParameter("AP_MATERNO", aP_MATERNO), New ObjectParameter("AP_MATERNO", GetType(String)))

        Dim nOMBREParameter As ObjectParameter = If(nOMBRE IsNot Nothing, New ObjectParameter("NOMBRE", nOMBRE), New ObjectParameter("NOMBRE", GetType(String)))

        Dim eMAILParameter As ObjectParameter = If(eMAIL IsNot Nothing, New ObjectParameter("EMAIL", eMAIL), New ObjectParameter("EMAIL", GetType(String)))

        Dim tELEFONOParameter As ObjectParameter = If(tELEFONO IsNot Nothing, New ObjectParameter("TELEFONO", tELEFONO), New ObjectParameter("TELEFONO", GetType(String)))

        Dim pASSWORDParameter As ObjectParameter = If(pASSWORD IsNot Nothing, New ObjectParameter("PASSWORD", pASSWORD), New ObjectParameter("PASSWORD", GetType(String)))

        Dim cODIGOParameter As ObjectParameter = If(cODIGO.HasValue, New ObjectParameter("CODIGO", cODIGO), New ObjectParameter("CODIGO", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("tu_sp_creaUsuario", pK_USER, aP_PATERNOParameter, aP_MATERNOParameter, nOMBREParameter, eMAILParameter, tELEFONOParameter, pASSWORDParameter, cODIGOParameter)
    End Function

    Public Overridable Function tu_sp_insertaTiempoAireTransact(id As ObjectParameter, ticket As String, companyId As String, terminalId As String, cATEGORIA As String, sKU As String, prefijoConnecta As String, email As String) As Integer
        Dim ticketParameter As ObjectParameter = If(ticket IsNot Nothing, New ObjectParameter("ticket", ticket), New ObjectParameter("ticket", GetType(String)))

        Dim companyIdParameter As ObjectParameter = If(companyId IsNot Nothing, New ObjectParameter("companyId", companyId), New ObjectParameter("companyId", GetType(String)))

        Dim terminalIdParameter As ObjectParameter = If(terminalId IsNot Nothing, New ObjectParameter("terminalId", terminalId), New ObjectParameter("terminalId", GetType(String)))

        Dim cATEGORIAParameter As ObjectParameter = If(cATEGORIA IsNot Nothing, New ObjectParameter("CATEGORIA", cATEGORIA), New ObjectParameter("CATEGORIA", GetType(String)))

        Dim sKUParameter As ObjectParameter = If(sKU IsNot Nothing, New ObjectParameter("SKU", sKU), New ObjectParameter("SKU", GetType(String)))

        Dim prefijoConnectaParameter As ObjectParameter = If(prefijoConnecta IsNot Nothing, New ObjectParameter("prefijoConnecta", prefijoConnecta), New ObjectParameter("prefijoConnecta", GetType(String)))

        Dim emailParameter As ObjectParameter = If(email IsNot Nothing, New ObjectParameter("email", email), New ObjectParameter("email", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("tu_sp_insertaTiempoAireTransact", id, ticketParameter, companyIdParameter, terminalIdParameter, cATEGORIAParameter, sKUParameter, prefijoConnectaParameter, emailParameter)
    End Function

    Public Overridable Function tu_sp_obtieneCodigosErrorServicios(idError As String) As ObjectResult(Of tu_sp_obtieneCodigosErrorServicios_Result)
        Dim idErrorParameter As ObjectParameter = If(idError IsNot Nothing, New ObjectParameter("idError", idError), New ObjectParameter("idError", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of tu_sp_obtieneCodigosErrorServicios_Result)("tu_sp_obtieneCodigosErrorServicios", idErrorParameter)
    End Function

    Public Overridable Function tu_sp_selectMovimientos(email As String, numerodeRegistros As Nullable(Of Integer)) As ObjectResult(Of tu_sp_selectMovimientos_Result)
        Dim emailParameter As ObjectParameter = If(email IsNot Nothing, New ObjectParameter("email", email), New ObjectParameter("email", GetType(String)))

        Dim numerodeRegistrosParameter As ObjectParameter = If(numerodeRegistros.HasValue, New ObjectParameter("numerodeRegistros", numerodeRegistros), New ObjectParameter("numerodeRegistros", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of tu_sp_selectMovimientos_Result)("tu_sp_selectMovimientos", emailParameter, numerodeRegistrosParameter)
    End Function

    Public Overridable Function tu_sp_selectTiempoAireTransact(id As Nullable(Of Integer)) As ObjectResult(Of tu_sp_selectTiempoAireTransact_Result)
        Dim idParameter As ObjectParameter = If(id.HasValue, New ObjectParameter("Id", id), New ObjectParameter("Id", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of tu_sp_selectTiempoAireTransact_Result)("tu_sp_selectTiempoAireTransact", idParameter)
    End Function

    Public Overridable Function tu_sp_obtieneDetalleTransacciones(fk_usuario As Nullable(Of Integer)) As ObjectResult(Of tu_sp_obtieneDetalleTransacciones_Result)
        Dim fk_usuarioParameter As ObjectParameter = If(fk_usuario.HasValue, New ObjectParameter("fk_usuario", fk_usuario), New ObjectParameter("fk_usuario", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of tu_sp_obtieneDetalleTransacciones_Result)("tu_sp_obtieneDetalleTransacciones", fk_usuarioParameter)
    End Function

End Class

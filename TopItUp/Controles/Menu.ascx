<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Menu.ascx.vb" Inherits="TopItUp.Menu" %>
<script src="../Scripts/jquery-1.10.2.js" type="text/javascript" ></script>

<script type="text/javascript">
    function GeneraMenu(arg) {
        $("#tblMenu").html(arg);
    }
</script>

<table id="tblMenu" border="0" cellpadding="0" cellspacing="0" class="auto-style10">
</table>
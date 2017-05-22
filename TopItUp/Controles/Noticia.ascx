<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Noticia.ascx.vb" Inherits="TopItUp.Noticia" %>

<style type="text/css">
    .auto-style10 {
        width: 114px;
    }
    .auto-style40 {
        font-size: medium;
    }
    .auto-style60 {
        width: 114px;
        height: 27px;
    }
    .auto-style70 {
        height: 27px;
        font-size: medium;
    }
    .auto-style80 {
        font-size: 15pt;
        font-style: italic;
    }
    .auto-style90 {
        width: 114px;
        font-size: 15pt;
    }
    .auto-style100 {
        font-size: 15pt;
    }
</style>

<div style="border:solid; border-width:2px">

    <table style="height: 69px; width: 929px; font-family: 'Century Gothic'; font-size: x-small;" border="0">
    <tr>
        
        <td class="auto-style40">
            <h3 style="text-align: center" class="auto-style40">NOTICIAS</h3>
        </td>
    </tr>
    <tr>
        
        <td>
            <asp:Label ID="lblDia" runat="server" style="font-weight: 700; display:none" Font-Strikeout="False" CssClass="auto-style80" Font-Size="Small"></asp:Label>
            
            <div id="dvHora" style="display:none"></div>
            <asp:Label ID="lblNoticia" runat="server" Font-Size="Medium"></asp:Label>
        </td>
    </tr>
    <tr>
       
        <td class="auto-style70">
            <table class="auto-style5">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>

</div>

<script>
    function digiClock() {
        var crTime = new Date();
        var crHrs = crTime.getHours();
        var crMns = crTime.getMinutes();
        var crScs = crTime.getSeconds();
        crMns = (crMns < 10 ? "0" : "") + crMns;
        crScs = (crScs < 10 ? "0" : "") + crScs;
        var timeOfDay = (crHrs < 12) ? "AM" : "PM";
        crHrs = (crHrs > 12) ? crHrs - 12 : crHrs;
        crHrs = (crHrs == 0) ? 12 : crHrs;
        var crTimeString = crHrs + ":" + crMns + ":" + crScs + " " + timeOfDay;

        $("#dvHora").empty();
        $("#dvHora").html('<span style="font-weight: 700;" class="auto-style80">' + crTimeString + '</span>');

    }

    $(document).ready(function () {
        setInterval('digiClock()', 1000);

    });

</script>
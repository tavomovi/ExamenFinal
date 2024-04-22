<%@ Page Language="C#" MasterPageFile="~/Capa Presentacion/Master/Menu.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ExamenFinal.Capa_Presentacion.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilos para centrar el texto, hacerlo grande y color blanco */
        .centered-text {
            text-align: center; /* Centra el texto */
            font-size: 36px; /* Tamaño grande de la fuente */
            color: white; /* Color blanco */
        }

        .centered-text2 {
            text-align: center; /* Centra el texto */
            font-size: 20px; /* Tamaño grande de la fuente */
            color: white; /* Color blanco */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class="centered-text">Examen 3 Programacion 3</div>
    <br />
    <br />
    <div class="centered-text2">
        Catalogo de Agente y Cliente<br />
        Con menu circular<br /><br /><br /><br />
        Estudiante: Luis Gustavo Montoya Villalobos<br />
    </div>

</asp:Content>

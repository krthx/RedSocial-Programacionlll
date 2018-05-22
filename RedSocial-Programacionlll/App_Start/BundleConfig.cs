using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace RedSocial_Programacionlll
{
    public class BundleConfig
    {
        // Para obtener más información sobre la unión, visite http://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/Content/Framework/WebForms/WebForms.js",
                            "~/Content/Framework/WebForms/WebUIValidation.js",
                            "~/Content/Framework/WebForms/MenuStandards.js",
                            "~/Content/Framework/WebForms/Focus.js",
                            "~/Content/Framework/WebForms/GridView.js",
                            "~/Content/Framework/WebForms/DetailsView.js",
                            "~/Content/Framework/WebForms/TreeView.js",
                            "~/Content/Framework/WebForms/WebParts.js"));

            // El orden es muy importante para el funcionamiento de estos archivos ya que tienen dependencias explícitas
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Content/Framework/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/Content/Framework/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/Content/Framework/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/Content/Framework/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use la versión de desarrollo de Modernizr para desarrollar y aprender. Luego, cuando esté listo
            // para la producción, use la herramienta de creación en http://modernizr.com para elegir solo las pruebas que necesite
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Content/Framework/Modernizr/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/extra").Include(
                            "~/Content/Framework/JQuery/jquery-3.3.1.min.js",
                            "~/Content/Framework/SemanticUI/semantic.min.js"));

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/Content/Framework/respond.min.js",
                    DebugPath = "~/Content/Framework/respond.js",
                });

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                            "~/Content/Framework/SemanticUI/semantic.min.css"));
        }
    }
}
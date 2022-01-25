using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Azure.Cosmos.Table;
using MigracionAlumnosAzure.Models;

namespace MigracionAlumnosAzure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void botonmigrar_Click(object sender, EventArgs e)
        {
            string keys = "DefaultEndpointsProtocol=https;AccountName=storageazurepgss;AccountKey=HpKr69wzaQqXaJ9/D2WogPwfq2QTj2NUYJMgGq8NedeV4/R8Lja4eByS5HlYUFzqJ0HYmO2sOR7BZlHf+NXMZA==;EndpointSuffix=core.windows.net";
            CloudStorageAccount account =
                CloudStorageAccount.Parse(keys);
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable tabla = client.GetTableReference("tablaalumnos");
            await tabla.CreateIfNotExistsAsync();
            //RECUPERAMOS EL DOCUMENTO XML, QUE LO HEMOS INCRUSTADO
            //DENTRO DE LA APLICACION
            //PARA RECUPERARLO, NECESITAMOS EL NOMBRE DE NUESTRA APP
            //Y EL NOMBRE DEL FICHERO
            Stream stream =
                this.GetType().Assembly.GetManifestResourceStream
                ("MigracionAlumnosAzure.alumnos.xml");
            //VAMOS A LEER EL CONTENIDO XML DEL ARCHIVO
            //PARA ELLO VAMOS A UTILIZAR LINQ TO XML
            XDocument document = XDocument.Load(stream);
            //SOBRE EL DOCUMENTO HACEMOS UNA CONSULTA PARA 
            //QUE NOS DEVUELVA TODAS LAS ETIQUETAS <alumno>
            var consulta = from datos in document.Descendants("alumno")
                           select datos;
            List<Alumno> alumnos = new List<Alumno>();
            //RECORREMOS TODOS LOS ELEMENTOS <alumno> DE LA CONSULTA
            foreach (var elemento in consulta)
            {
                //CREAMOS UN NUEVO ALUMNO
                Alumno alumno = new Alumno();
                //ASIGNAMOS CADA ETIQUETA DEL <alumno> A LA CLASE
                alumno.IdAlumno = elemento.Element("idalumno").Value;
                alumno.Curso = elemento.Element("curso").Value;
                alumno.Nombre = elemento.Element("nombre").Value;
                alumno.Apellidos = elemento.Element("apellidos").Value;
                alumno.Nota = elemento.Element("nota").Value;
                //AGREGAMOS CADA ALUMNO A LA COLECCION
                alumnos.Add(alumno);
            }
            this.labelmensaje.Text = "Alumnos: " + alumnos.Count;
            //RECORREMOS TODA LA COLECCION DE ALUMNOS
            //Y NOS LA LLEVAMOS A LA TABLA DE AZURE
            foreach (Alumno alumn in alumnos)
            {
                TableOperation insert = TableOperation.Insert(alumn);
                await tabla.ExecuteAsync(insert);
            }
        }
    }
}

using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigracionAlumnosAzure.Models
{
    public class Alumno: TableEntity
    {
        private string _IdAlumno;

        public string IdAlumno
        {
            get { return this._IdAlumno; }
            set {
                this._IdAlumno = value;
                this.RowKey = value;
            }
        }

        private string _Curso;
        public string Curso
        {
            get { return this._Curso; }
            set {
                this._Curso = value;
                this.PartitionKey = value;
            }
        }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Nota { get; set; }
    }
}

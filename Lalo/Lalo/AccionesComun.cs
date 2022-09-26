using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Lalo
{
    class AccionesComun
    {
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LlenarCombo(string consulta, ComboBox combo, string id, string nombre)
        {
            combo.ValueMember = id;
            combo.DisplayMember = nombre;
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            dt.Rows.Add(0, "TODOS");
            if (dt == null)
            {
                return;
            }
            combo.Items.Clear();
            combo.DataSource = dt;

        }
        public static void LlenarListView(string consulta, ListView list)
        {
            list.Clear();
            DataTable dt;
            list.GridLines = true;
            list.View = View.Details;
            ListViewItem campo;
            dt = Conexion.EjecutaSeleccion(consulta);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                list.Columns.Add(dt.Columns[i].ColumnName, 100);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                campo = new ListViewItem(dr[dt.Columns[0].ColumnName].ToString());
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    campo.SubItems.Add(dr[dt.Columns[j].ColumnName].ToString());
                }
                list.Items.Add(campo);
            }


        }
        public static void LlenarData(string consulta,DataGridView dtg)
        {
            DataTable dt = new DataTable();
            dt = Conexion.EjecutaSeleccion(consulta);
            dtg.DataSource = dt;
        }

    }
}

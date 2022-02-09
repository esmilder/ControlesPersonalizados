using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogisticDesk.UI.Componentes
{
    public partial class ListItemCustomImportaciones : UserControl
    {
        public ListItemCustomImportaciones()
        {
            InitializeComponent();
            DoubleBuffered = true;
            //MouseEnter += (sender, e) =>
            //{
            //    _isHovering = true;
            //    Invalidate();
            //};
            //MouseLeave += (sender, e) =>
            //{
            //    _isHovering = false;
            //    Invalidate();
            //};
        }

        private string _IdImportacion;
        private string _Estado;
        //private Color _onHoverColor = Color.DodgerBlue;
        //private Color _ColorDef = Color.WhiteSmoke;
        //private bool _isHovering;

        [Category("Custom prop")]
        public string IdImportacion
        {
            get { return _IdImportacion; }
            set { _IdImportacion = value; lblIdImportacion.Text = value; }
        }

        [Category("Custom prop")]
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; lblEstado.Text = value; }
        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics g = e.Graphics;
        //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //    Brush brush = new SolidBrush(_isHovering ? _onHoverColor : _ColorDef);

        //    //Border
        //    g.FillEllipse(brush, 0, 0, Height, Height);
        //    g.FillEllipse(brush, Width - Height, 0, Height, Height);
        //    g.FillRectangle(brush, Height / 2, 0, Width - Height, Height);
        //}
        //public Color OnHoverColor
        //{
        //    get => _onHoverColor;
        //    set
        //    {
        //        _onHoverColor = value;
        //        Invalidate();
        //    }
        //}

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Importacion n° "+ lblIdImportacion.Text);
        }
    }
}

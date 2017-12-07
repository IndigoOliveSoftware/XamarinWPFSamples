using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndigoOliveWPFVISX {
    public partial class IndigoOliveForm : Form {
        public enum IndigoOliveSelectedType {
            MASTER_DETAIL_PCL,
            EMPTY_PCL,
            MASTER_DETAIL_PCL_MAPS,
            MASTER_DETAIL_SHARE,
            EMPTY_SHARE,
            INDIGO_OLIVE_NONE
        };

        public static IndigoOliveSelectedType mg_eSelectedType = IndigoOliveSelectedType.INDIGO_OLIVE_NONE;

        public IndigoOliveForm() {
            InitializeComponent();
        }

        private void OnCreateButtonClicked(object sender, EventArgs e) {
            bool bAnyClicked = false;

            if (radioButton1.Checked) {
                bAnyClicked = true;
                mg_eSelectedType = IndigoOliveSelectedType.MASTER_DETAIL_PCL;
            } else if (radioButton2.Checked) {
                bAnyClicked = true;
                mg_eSelectedType = IndigoOliveSelectedType.EMPTY_PCL;
            } else if (radioButton3.Checked) {
                bAnyClicked = true;
                mg_eSelectedType = IndigoOliveSelectedType.MASTER_DETAIL_PCL_MAPS;
            } else if (radioButton4.Checked) {
                bAnyClicked = true;
                mg_eSelectedType = IndigoOliveSelectedType.MASTER_DETAIL_SHARE;
            } else if (radioButton5.Checked) {
                bAnyClicked = true;
                mg_eSelectedType = IndigoOliveSelectedType.EMPTY_SHARE;
            }

            if (!bAnyClicked) {
                mg_eSelectedType = IndigoOliveSelectedType.INDIGO_OLIVE_NONE;
            }
            this.Close();
        }

        private void OnCancelButtonClicked(object sender, EventArgs e) {
            mg_eSelectedType = IndigoOliveSelectedType.INDIGO_OLIVE_NONE;
            this.Close();
        }
    }
}

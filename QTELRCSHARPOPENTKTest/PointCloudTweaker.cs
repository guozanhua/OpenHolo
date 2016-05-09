using System;
using System.Windows.Forms;
using System.Numerics;

/*
This represents a form with various inputs that allow you to control the orientation of one of the point clouds being rendered.
This is for calibration.
*/
namespace OpenHolo
{
    public partial class PointCloudTweaker : Form
    {
        public PointCloudTweaker()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            EuclideanTransform transformation;
            transformation = new EuclideanTransform();
            transformation.translation = new Vector3(float.Parse(textbox_vx.Text), float.Parse(textbox_vy.Text), float.Parse(textbox_vz.Text));
            transformation.rotation = new Quaternion(float.Parse(textbox_qx.Text), float.Parse(textbox_qy.Text), float.Parse(textbox_qz.Text), float.Parse(textbox_qw.Text));
            PointCloudManipulation.setTransform(transformation);
        }
    }
}

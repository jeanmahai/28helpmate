using System;
using System.Windows.Forms;

namespace Helpmate.UI.Forms.UIContorl.Common
{
    public class OpaqueCommand
    {
        private UCOpaqueLayer m_OpaqueLayer = null;//°ëÍ¸Ã÷ÃÉ°å²ã

        /// <summary>
        /// ÏÔÊ¾ÕÚÕÖ²ã
        /// </summary>
        /// <param name="control">¿Ø¼þ</param>
        /// <param name="alpha">Í¸Ã÷¶È</param>
        /// <param name="isShowLoadingImage">ÊÇ·ñÏÔÊ¾Í¼±ê</param>
        public void ShowOpaqueLayer(Form control, int alpha, bool isShowLoadingImage)
        {
            try
            {
                if (this.m_OpaqueLayer == null)
                {
                    this.m_OpaqueLayer = new UCOpaqueLayer(alpha, isShowLoadingImage);
                    control.Controls.Add(this.m_OpaqueLayer);
                    this.m_OpaqueLayer.Dock = DockStyle.Fill;
                    this.m_OpaqueLayer.BringToFront();
                }
                this.m_OpaqueLayer.Enabled = true;
                this.m_OpaqueLayer.Visible = true;
            }
            catch { }
        }

        /// <summary>
        /// Òþ²ØÕÚÕÖ²ã
        /// </summary>
        public void HideOpaqueLayer()
        {
            try
            {
                if (this.m_OpaqueLayer != null)
                {
                    this.m_OpaqueLayer.Visible = false;
                    this.m_OpaqueLayer.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

    }
}

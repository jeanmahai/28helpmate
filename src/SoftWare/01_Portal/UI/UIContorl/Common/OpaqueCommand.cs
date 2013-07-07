using System;
using System.Windows.Forms;

namespace Helpmate.UI.Forms.UIContorl.Common
{
    public class OpaqueCommand
    {
        private UCOpaqueLayer m_OpaqueLayer = null;//��͸���ɰ��

        /// <summary>
        /// ��ʾ���ֲ�
        /// </summary>
        /// <param name="control">�ؼ�</param>
        /// <param name="alpha">͸����</param>
        /// <param name="isShowLoadingImage">�Ƿ���ʾͼ��</param>
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
        /// �������ֲ�
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

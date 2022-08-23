using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FveyeWebAPI.Models;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.HtmlControls;
/*加載 Nuget
* emgu.CV
* emgu.runtime.windows ?
* emgu.Bipmap
* emgu. UI
* **opencv  emgucv 官網抓 cvextern.dll檔
* System.Windows.Forms ?
* System.Drawing.Imaging
* System.Web.UI.DataVisualization.Charting
*/


namespace test
{
    public partial class test : System.Web.UI.Page
    {
        static string CompID;
        static string CustID;
        
        static Point p_center = new Point(0, 0);
        static int InsideCRadius = 10;
        static int OutsideCRadius = 150;        
        static int circle_r = InsideCRadius + (OutsideCRadius - InsideCRadius) / 3;
        static int circle2_r = InsideCRadius + 2 * (OutsideCRadius - InsideCRadius) / 3;

        static System.Windows.Forms.PictureBox originalImg_form  = new System.Windows.Forms.PictureBox();

        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        


        public void btn_search_CLick(object sender, EventArgs e)
        {
            GetApi ga = new GetApi();

            string compID = Request.Form["input_CompID"];
            string custID = Request.Form["input_CustID"];
            CompID = compID;
            CustID = custID;
            Task<List<Company>> task_company = ga.GetAllCompanys();
            Task<List<Check>> task_Check = ga.GetCustCheck(compID, custID);


            ListBox1.Items.Clear();
            

            if (task_Check.Result != null)
            {
                List<Check> task_customer_Irise = task_Check.Result;
                foreach (var Irise_item in task_customer_Irise)
                {
                    ListBox1.Items.Add(Irise_item.Iris_Left);
                    //listbox 添加

                    /*
                    originalImg.ImageUrl = "https://iriskenkou.s3.ap-northeast-1.amazonaws.com/Fveye_Img/CheckPic/" + compID + "/" + custID + "/" + Irise_item.Iris_Left + ".jpg";
                    */

                }
            }

        }

        public void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int ID = ListBox1.SelectedIndex + 1;
            if (ListBox1.SelectedItem != null)
            {
                lab_Irise.Text = ListBox1.SelectedItem.Text;
                originalImg.ImageUrl = "https://iriskenkou.s3.ap-northeast-1.amazonaws.com/Fveye_Img/CheckPic/" + CompID + "/" + CustID + "/" + ListBox1.SelectedItem.Text + ".jpg";
                GetApi ga = new GetApi();
                Task<AnalysisData_Iris_Post> AnalysisData_Iris_Post = ga.GetAnalysis(CompID, CustID, ID);
                if (AnalysisData_Iris_Post.Result != null)
                {
                    AnalysisData_Iris_Post analysisData_irist = AnalysisData_Iris_Post.Result;
                    p_center = new Point(analysisData_irist.CenterPoint_X, analysisData_irist.CenterPoint_Y);
                    InsideCRadius = analysisData_irist.InsideCRadius;
                    OutsideCRadius = analysisData_irist.OutsideCRadius;
                    circle_r = InsideCRadius + (OutsideCRadius - InsideCRadius) / 3;
                    circle2_r = InsideCRadius + 2 * (OutsideCRadius - InsideCRadius) / 3;
                }
            }

        

        }



        public void inttry()
        {
            int[,] parts = new int[2, 3];
            foreach(var v in parts)
                System.Diagnostics.Debug.WriteLine(v);
        }

        public void ana_hsv()
        {
            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap abc = (Bitmap)originalImg_form.Image;
            Image<Hsv, byte> draw_hsv_Img = abc.ToImage<Hsv, byte>();

 
            MemoryStream ms3 = new MemoryStream();
            draw_hsv_Img.ToBitmap().Save(ms3, ImageFormat.Jpeg);
            var base64Data3 = Convert.ToBase64String(ms3.ToArray());
            ImgArea0.ImageUrl = "data:image/gif;base64," + base64Data3;
        }

        public void show_canny(System.Web.UI.WebControls.Image image, byte canny_byte, byte canny_byte2)
        {
            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap abc = (Bitmap)originalImg_form.Image;
            Image<Rgb, byte> anaRgb_Img = abc.ToImage<Rgb, byte>();
            //加canny
          //  Mat src = new Image<Bgr, byte>(abc).Mat;
            Mat dst = new Mat();


            CvInvoke.Canny(anaRgb_Img, dst, canny_byte, canny_byte2);

            MemoryStream ms3 = new MemoryStream();
            dst.ToBitmap().Save(ms3, ImageFormat.Jpeg);
            var base64Data3 = Convert.ToBase64String(ms3.ToArray());
            image.ImageUrl = "data:image/gif;base64," + base64Data3;
        }

        public void ana_try()
        {
            

            int InsideCRadius_1 = InsideCRadius + 10;

            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap abc = (Bitmap)originalImg_form.Image;
            
            Image<Rgb, byte> draw_ana_Img = abc.ToImage<Rgb, byte>();



            Image<Rgb, byte> anaRgb_Img = abc.ToImage<Rgb, byte>();
            Image<Gray, byte> anaGray_Img = abc.ToImage<Gray, byte>();

            Bitmap newbitmap = new Bitmap(640, 480, PixelFormat.Format32bppRgb);
            Image<Rgb, byte> newimage = newbitmap.ToImage<Rgb, byte>();

            List<int> PixelGray_in = new List<int>();

            Series series_insidecircle = new Series("insidecircle", 800);
            Series series_statistic  = new Series("insidecircle", 800);

            Insidecircle2_ChartArea.Series.Clear();
            ListBox2.Items.Clear();
            int a = 0;
            int b = 0;
            //內圈分析
            for (int w = 0; w < anaRgb_Img.Width; w++)
            {
                for (int h = 0; h < anaRgb_Img.Height; h++)
                {
                    double dis = Math.Sqrt(Math.Pow(w - p_center.X, 2) + Math.Pow(h - p_center.Y, 2));
                    if (InsideCRadius < dis && dis < OutsideCRadius)
                    {
                        PixelGray_in.Add(anaGray_Img.Data[h, w, 0]);
                        series_statistic.Points.Add(anaGray_Img.Data[h, w, 0]);

                        newimage.Data[h, w , 0] = draw_ana_Img.Data[h, w, 0];
                        newimage.Data[h, w, 1] = draw_ana_Img.Data[h, w, 1];
                        newimage.Data[h, w, 2] = draw_ana_Img.Data[h, w, 2];
                        a = a + anaGray_Img.Data[h, w, 0];
                        //System.Diagnostics.Debug.WriteLine("("+w+","+h+")"+anaGray_Img.Data[h, w, 0]);
                        b++;
                    }
                }
            }

            System.Diagnostics.Debug.WriteLine(a);
            System.Diagnostics.Debug.WriteLine(b);

            ChartArea chartarea = new ChartArea();
            chartarea.AxisY.Maximum = 256;
            Insidecircle2_ChartArea.ChartAreas.Clear();
            Insidecircle2_ChartArea.ChartAreas.Add(chartarea);

            Insidecircle2_ChartArea.Series.Add(series_statistic);
            
            double mean = Insidecircle2_ChartArea.DataManipulator.Statistics.Mean(series_statistic.Name);
            double variance = Insidecircle2_ChartArea.DataManipulator.Statistics.Variance(series_statistic.Name,false);
            double standard = Math.Sqrt(variance);
            double abcd = PixelGray_in.Average();


            lab_mean.Text = Convert.ToString(abcd+"/"+mean);
            lab_var.Text = Convert.ToString(variance);
            lab_StaDev.Text = Convert.ToString(standard);

            System.Diagnostics.Debug.WriteLine(a);
            System.Diagnostics.Debug.WriteLine(b);
            /*
            for (int w = 0; w < anaRgb_Img.Width; w++)
            {
                for (int h = 0; h < anaRgb_Img.Height; h++)
                {
                    double dis = Math.Sqrt(Math.Pow(w - p_center.X, 2) + Math.Pow(h - p_center.Y, 2));
                    if (InsideCRadius < dis && dis < OutsideCRadius)
                    {
                        if (anaGray_Img.Data[h, w, 0] - (mean - 1.05*standard) < 0)
                        {
                            draw_ana_Img.Data[h, w, 0] = 255;
                            draw_ana_Img.Data[h, w, 1] = 255;
                            draw_ana_Img.Data[h, w, 2] = 255;

                        }
                    }
                }
            }
            */
            CvInvoke.Circle(draw_ana_Img, p_center, InsideCRadius, new MCvScalar(255, 255, 0), 1, Emgu.CV.CvEnum.LineType.EightConnected, 0);
            CvInvoke.Circle(draw_ana_Img, p_center, OutsideCRadius, new MCvScalar(255, 255, 0), 1, Emgu.CV.CvEnum.LineType.EightConnected, 0);

            MemoryStream ms = new MemoryStream();
            draw_ana_Img.ToBitmap().Save(ms, ImageFormat.Jpeg);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            ImgInsidecircle2.ImageUrl = "data:image/gif;base64," + base64Data;
            
            MemoryStream ms2 = new MemoryStream();
            newimage.ToBitmap().Save(ms2, ImageFormat.Jpeg);
            var base64Data2 = Convert.ToBase64String(ms2.ToArray());
            img1.ImageUrl = "data:image/gif;base64," + base64Data2;

           

        }




        public void draw_inoutsidecircle()
        {
            int InsideCRadius_1 = InsideCRadius - 5;
            int InsideCRadius_2 = InsideCRadius + 5;
            int OutsideCRadius_1 = OutsideCRadius - 5;
            int OutsideCRadius_2 = OutsideCRadius + 5;
            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap bmp = (Bitmap)originalImg_form.Image;
            Image<Gray, byte> iris_ana_Img = bmp.ToImage<Gray, byte>();
            Image<Rgb, byte> draw_ana_Img = bmp.ToImage<Rgb, byte>();
            List<int> PixelGray = new List<int>();
            //內圈繪製
            for (int w = 0; w < iris_ana_Img.Width; w++)
            {
                for (int h = 0; h < iris_ana_Img.Height; h++)
                {
                    double dis = Math.Sqrt(Math.Pow(w - p_center.X, 2) + Math.Pow(h - p_center.Y, 2));
                    if (InsideCRadius_1 < dis && dis < InsideCRadius_2)
                    {
                        draw_ana_Img.Data[h, w, 0] = 200;
                    }
                }
            }
            //外圈繪製
            for (int w = 0; w < draw_ana_Img.Width; w++)
            {
                for (int h = 0; h < draw_ana_Img.Height; h++)
                {
                    double dis = Math.Sqrt(Math.Pow(w - p_center.X, 2) + Math.Pow(h - p_center.Y, 2));
                    if (OutsideCRadius_1 < dis && dis < OutsideCRadius_2)
                    {
                        draw_ana_Img.Data[h, w, 0] = 200;
                    }
                }
            }

            MemoryStream ms = new MemoryStream();
            draw_ana_Img.ToBitmap().Save(ms, ImageFormat.Jpeg);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            img1.ImageUrl = "data:image/gif;base64," + base64Data;
        }
        /*
        public void ana_insidecircle()
        {

            int InsideCRadius_1 = InsideCRadius - 5;
            int InsideCRadius_2 = InsideCRadius + 5;

            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap abc = (Bitmap)originalImg_form.Image;
            Image<Rgb, byte> ana_Img = abc.ToImage<Rgb, byte>();

            Image<Rgb, byte> anaRgb_Img = abc.ToImage<Rgb, byte>();
            Image<Gray, byte> anaGray_Img = abc.ToImage<Gray, byte>();

            List<int> PixelGray_in = new List<int>();

            Series series_insidecircle = new Series("insidecircle", 800);

            Chart1.Series.Clear();

            //內圈分析
            for (int w = 0; w < anaRgb_Img.Width; w++)
            {
                for (int h = 0; h < anaRgb_Img.Height; h++)
                {
                    double dis = Math.Sqrt(Math.Pow(w - p_center.X, 2) + Math.Pow(h - p_center.Y, 2));
                    if (InsideCRadius_1 < dis && dis < InsideCRadius_2)
                    {
                        PixelGray_in.Add(anaGray_Img.Data[h, w, 0]);
                    }
                }
            }
            for (int color = 0; color <= 255; color++)
            {
                int colorCount = 0;
                foreach (var s in PixelGray_in)
                {
                    if (s == color)
                        colorCount++;
                }
                series_insidecircle.Points.AddXY(color, colorCount);
            }



            ChartArea chartarea = new ChartArea();
            chartarea.AxisY.Maximum = 400;
            Chart1.ChartAreas.Clear();
            Chart1.ChartAreas.Add(chartarea);

            Chart1.Series.Add(series_insidecircle);
        }
        */
        
        /*
        public void ana_outsidecircle()
        {
            
            int OutsideCRadius_1 = OutsideCRadius - 5;
            int OutsideCRadius_2 = OutsideCRadius + 5;
            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap abc = (Bitmap)originalImg_form.Image;


            Image<Rgb, byte> anaRgb_Img = abc.ToImage<Rgb, byte>();
            Image<Gray, byte> anaGray_Img = abc.ToImage<Gray, byte>();

            List<int> PixelGray_out = new List<int>();

            Series series_outsidecircle = new Series("outsidecircle", 800);

            Chart2.Series.Clear();

            //外圈分析
            for (int w = 0; w < anaGray_Img.Width; w++)
            {
                for (int h = 0; h < anaGray_Img.Height; h++)
                {
                    double dis = Math.Sqrt(Math.Pow(w - p_center.X, 2) + Math.Pow(h - p_center.Y, 2));
                    if (OutsideCRadius_1 < dis && dis < OutsideCRadius_2)
                    {
                        PixelGray_out.Add(anaGray_Img.Data[h, w, 0]);
                    }
                }
            }
            for (int color = 0; color <= 255; color++)
            {
                int colorCount = 0;
                foreach (var s in PixelGray_out)
                {
                    if (s == color)
                        colorCount++;
                }
                series_outsidecircle.Points.AddXY(color, colorCount);
            }
            Chart2.Series.Add(series_outsidecircle);
        }
        */
        public Image<Rgb, byte>draw_ellipse(Image<Rgb, byte> draw_ana_Img,int r,double startdegree,double enddegree)
        {
            Image<Rgb, byte> Img= draw_ana_Img;
            double starangle = startdegree * 30 ;
            double endangle = enddegree * 30 ;
            CvInvoke.Ellipse(Img, p_center,new Size(r,r),  0, starangle, endangle, new MCvScalar(255, 255, 0), 1, Emgu.CV.CvEnum.LineType.EightConnected, 0);
            return  Img;
        }
        //圖片從左上開始繪圖，上下相反角度要小心
        public Image<Rgb, byte> draw_line(Image<Rgb, byte> draw_ana_Img, int degree_int)
        {
            //圖片從左上開始繪圖，上下相反角度要小心
            Image<Rgb, byte> Img = draw_ana_Img;
            double angle = degree_int * 30 * Math.PI / 180;
            int x1 = Convert.ToInt32(p_center.X + Math.Floor(InsideCRadius * Math.Cos(angle)));
            int y1 = Convert.ToInt32(p_center.Y + Math.Floor(InsideCRadius * Math.Sin(angle)));
            int x2 = Convert.ToInt32(p_center.X + Math.Floor(OutsideCRadius * Math.Cos(angle)));
            int y2 = Convert.ToInt32(p_center.Y + Math.Floor(OutsideCRadius * Math.Sin(angle)));
            Point p1 = new Point(x1, y1);
            Point p2 = new Point(x2, y2);
            CvInvoke.Line(Img, p1, p2, new MCvScalar(255, 255, 0), 1);
            return Img;
        }

        public void ana_Area(System.Web.UI.WebControls.Image image, int degree, System.Web.UI.DataVisualization.Charting.Chart argchart1, System.Web.UI.DataVisualization.Charting.Chart argchart2, System.Web.UI.DataVisualization.Charting.Chart argchart3)
        {
            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap abc = (Bitmap)originalImg_form.Image;
            Image<Gray, byte> ana_Img = abc.ToImage<Gray, byte>();
            Image<Rgb, byte> draw_ana_Img = abc.ToImage<Rgb, byte>();

            int degree_int = degree;

            List<int> Pixel_Area_1 = new List<int>();
            List<int> Pixel_Area_2 = new List<int>();
            List<int> Pixel_Area_3 = new List<int>();
            argchart1.Series.Clear();
            argchart2.Series.Clear();
            argchart3.Series.Clear();
            Series series_Area_1 = new Series("Gray", 800);
            Series series_Area_2 = new Series("Gray", 800);
            Series series_Area_3 = new Series("Gray", 800);
            




            /* 1 */
            for (int w = 0; w < ana_Img.Width; w++)
            {
                for (int h = 0; h < ana_Img.Height; h++)
                {
                    double dis = Math.Sqrt(Math.Pow(w - p_center.X, 2) + Math.Pow(h - p_center.Y, 2));
                    //(w,h)的角度
                    var _vector = new Point(w - p_center.X, h - p_center.Y);
                    var angle = _vector.X / (Math.Sqrt(Math.Pow(_vector.X, 2.0) + Math.Pow(_vector.Y, 2.0)));
                    var degree_p2 = (Math.Acos(angle) * 180 / Math.PI);
                    if (_vector.Y < 0) { }
                    else
                        degree_p2 = 360 - degree_p2;

                    int degree_p2_int = (int)degree_p2 / 30;

                    if (InsideCRadius <= dis && dis <= circle_r && degree_int == degree_p2_int)
                    {
                        Pixel_Area_1.Add(ana_Img.Data[h, w, 0]);
                        draw_ana_Img.Data[h, w, 0] = ana_Img.Data[h, w, 0];
                        draw_ana_Img.Data[h, w, 1] = ana_Img.Data[h, w, 0];
                        draw_ana_Img.Data[h, w, 2] = ana_Img.Data[h, w, 0];
                    }
                    else if
                        (circle_r <= dis && dis <= circle2_r && degree_int == degree_p2_int)
                    {
                        Pixel_Area_2.Add(ana_Img.Data[h, w, 0]);
                        draw_ana_Img.Data[h, w, 0] = ana_Img.Data[h, w, 0];
                        draw_ana_Img.Data[h, w, 1] = ana_Img.Data[h, w, 0];
                        draw_ana_Img.Data[h, w, 2] = ana_Img.Data[h, w, 0];
                    }
                    else if
                        (circle2_r <= dis && dis <= OutsideCRadius && degree_int == degree_p2_int)
                    {
                        Pixel_Area_3.Add(ana_Img.Data[h, w, 0]);
                        draw_ana_Img.Data[h, w, 0] = ana_Img.Data[h, w, 0];
                        draw_ana_Img.Data[h, w, 1] = ana_Img.Data[h, w, 0];
                        draw_ana_Img.Data[h, w, 2] = ana_Img.Data[h, w, 0];
                    }
                }
            }
            //gray1
            for (int color = 0; color <= 255; color++)
            {
                int colorCount = 0;
                foreach (var s in Pixel_Area_1)
                {
                    if (s == color)
                        colorCount++;
                }
                series_Area_1.Points.AddXY(color, colorCount);
            }
            //2
            for (int color = 0; color <= 255; color++)
            {
                int colorCount = 0;
                foreach (var s in Pixel_Area_2)
                {
                    if (s == color)
                        colorCount++;
                }
                series_Area_2.Points.AddXY(color, colorCount);
            }
            //3
            for (int color = 0; color <= 255; color++)
            {
                int colorCount = 0;
                foreach (var s in Pixel_Area_3)
                {
                    if (s == color)
                        colorCount++;
                }
                series_Area_3.Points.AddXY(color, colorCount);
            }


            //圖片從左上開始，所以角度剛好相反  加上 -號
            int startdegree = -degree;
            int enddegree = -degree-1;
            draw_ana_Img = draw_ellipse(draw_ana_Img, InsideCRadius, startdegree, enddegree);
            draw_ana_Img = draw_ellipse(draw_ana_Img, OutsideCRadius, startdegree, enddegree);
            draw_ana_Img = draw_ellipse(draw_ana_Img, circle_r, startdegree, enddegree);
            draw_ana_Img = draw_ellipse(draw_ana_Img, circle2_r, startdegree, enddegree);
            draw_ana_Img = draw_line(draw_ana_Img, startdegree);
            draw_ana_Img = draw_line(draw_ana_Img, enddegree);

            //用來固定圖表Y值 //只用同一個chartarea 不知道為甚麼會出錯
            ChartArea chartarea1 = new ChartArea();
            ChartArea chartarea2 = new ChartArea();
            ChartArea chartarea3 = new ChartArea();
            chartarea1.AxisY.Maximum = 400;
            chartarea2.AxisY.Maximum = 400;
            chartarea3.AxisY.Maximum = 400;

            argchart1.ChartAreas.Clear();
            argchart2.ChartAreas.Clear();
            argchart3.ChartAreas.Clear();

            argchart1.ChartAreas.Add(chartarea1);
            argchart2.ChartAreas.Add(chartarea2);
            argchart3.ChartAreas.Add(chartarea3);


            argchart1.Series.Add(series_Area_1);
            argchart2.Series.Add(series_Area_2);
            argchart3.Series.Add(series_Area_3);

            MemoryStream ms = new MemoryStream();
            draw_ana_Img.ToBitmap().Save(ms, ImageFormat.Jpeg);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            image.ImageUrl = "data:image/gif;base64," + base64Data;
        }

        public void draw_Emgu()
        {
            originalImg_form.Load(originalImg.ImageUrl);
            Bitmap bmp = (Bitmap)originalImg_form.Image;
            Image<Gray, byte> iris_ana_Img = bmp.ToImage<Gray, byte>();
            Image<Rgb, byte> draw_ana_Img = bmp.ToImage<Rgb, byte>();
            Mat scr = new Mat();
            Mat dst = new Mat();
            Mat element = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross,new Size(3, 3), new Point(-1, -1));

            CvInvoke.Erode(iris_ana_Img, scr, element, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0, 0, 0));
            CvInvoke.Dilate(scr, dst, element, new Point(-1, -1), 1,Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0, 0, 0));

            MemoryStream ms = new MemoryStream();
            dst.ToBitmap().Save(ms, ImageFormat.Jpeg);
            var base64Data = Convert.ToBase64String(ms.ToArray());
            ImgArea0.ImageUrl = "data:image/gif;base64," + base64Data;
        }

        protected void btn_hsv_Click(object sender, EventArgs e)
        {
            byte byte_input_hsvbar_text = Convert.ToByte(input_hsvbar.Value);
            ana_hsv();
            
            show_canny(ImgArea1, byte_input_hsvbar_text, byte_input_hsvbar_text);
            show_canny(ImgArea2, 50, 50);
            show_canny(ImgArea3, 75, 75);
            input_hsvbar_text.Text = input_hsvbar.Value;
        }

        protected void in_outsidecircle_Click(object sender, EventArgs e)
        {
            ana_try();
            draw_Emgu();
        }

        /*end*/

    }
}
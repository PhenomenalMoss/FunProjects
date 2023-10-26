using System;
using System.IO;
namespace CheckYourPCSetup
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setups.Add(new PC(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text));
            PC.AddSetup(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            label9.Text = "It's saved!";
            //Thread.Sleep(2000);
            //label9.Text = "";
        }
        List<PC> Setups = new List<PC>();
    }
    interface IPower
    {
        string power { get; set; }
    }
    interface IMom
    {
        string mom { get; set; }
    }
    interface IProcessor
    {
        string processor { get; set; }
        //public int CheckProcessor(string processor, string mom, int error);
    }
    interface IFastMemory
    {
        string fast_memory { get; set; }
    }
    interface IVideoCard
    {
        string video_card { get; set; }
    }
    class PC : IPower, IMom, IProcessor, IFastMemory, IVideoCard
    {
        public string power { get; set; }
        public string mom { get; set; }
        public string processor { get; set; }
        public string fast_memory { get; set; }
        public string video_card { get; set; }
        public PC(string power, string mom, string processor, string fast_memory, string video_card)
        {
            if (power != "")
                this.power = power;
            else
                this.power = "null";
            if (mom != "")
                this.mom = mom;
            else
                this.mom = "null";
            if (processor != "")
                this.processor = processor;
            else
                this.processor = "null";
            if (fast_memory != "")
                this.fast_memory = fast_memory;
            else
                this.fast_memory = "null";
            if (video_card != "")
                this.video_card = video_card;
            else
                this.video_card = "null";
        }
        public static void AddSetup(string power, string mom, string processor, string fast_memory, string video_card)
        {
            string path = @"Setups.txt";
            if (File.Exists(path))
            {
                string appendText = power + "/" + mom + "/" + processor + "/" + fast_memory + "/" + video_card + Environment.NewLine;
                File.AppendAllText(path, appendText);
            }
            

        }
        /*public int CheckProcessor(string processor, string mom, int error) //потом реализую сравнение разъемов для каждого элемента 
        {
            try
            {
                StreamReader srm = new StreamReader("Mom.txt");
                StreamReader srproc = new StreamReader("Proc.txt");
                string str = srm.ReadLine();
                string m = str.Split('/')[0];
                while (m!=mom)
                {
                    str = srm.ReadLine();
                    m = str.Split('/')[0];
                }
                m = str.Split('/')[1];
                str = srproc.ReadLine();
                string proc = str.Split('/')[0];
                while (proc!=processor)
                {
                    str = srproc.ReadLine();
                    proc = str.Split('/')[0];
                }
                proc = str.Split('/')[1];
                if(proc!=m)
                    error++;
                return error;
            }
            catch (Exception)
            {
                return error++;
            }
        }*/
    }
}
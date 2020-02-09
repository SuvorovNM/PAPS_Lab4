using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    enum Widget { Button, Picture, Panel, Tab, Toolbar, Textbox}

    interface UserInterface
    {
        void CreateDash(List<Widget> wList);
        void CreateWidget(Widget w);
        void RemoveWidget(Widget w);
        void ShowDash();
    }

    class ProxyDash : UserInterface
    {
        Dashboard dash;

        public void CreateDash(List<Widget> wList)
        {
            if (dash == null)
            {
                dash = new Dashboard();
            }
            dash.CreateDash(wList);
        }

        public void CreateWidget(Widget w)
        {
            if (dash == null)
            {
                dash = new Dashboard();
                dash.CreateDash(null);
            }
            dash.CreateWidget(w);
        }

        public void RemoveWidget(Widget w)
        {
            if (dash == null)
                throw new Exception("Dash hasn't been created!");
            else
                dash.RemoveWidget(w);
        }

        public void ShowDash()
        {
            if (dash == null)
                throw new Exception("Dash hasn't been created!");
            else
                dash.ShowDash();
        }
    }

    class Dashboard : UserInterface
    {
        List<Widget> widgets;
        public void CreateDash(List<Widget> wList)
        {
            widgets = wList;
        }

        public void CreateWidget(Widget w)
        {
            widgets.Add(w);
        }

        public void RemoveWidget(Widget w)
        {
            if (widgets.Contains(w))
                widgets.Remove(w);
        }

        public void ShowDash()
        {
            Console.WriteLine("Dash contains: ");
            foreach (Widget w in widgets)
            {
                Console.WriteLine(w);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UserInterface UI = new ProxyDash();
            UI.CreateDash(new List<Widget>() { Widget.Button, Widget.Panel, Widget.Panel, Widget.Textbox });
            UI.CreateWidget(Widget.Picture);
            UI.RemoveWidget(Widget.Textbox);
            UI.ShowDash();
            Console.ReadLine();
        }
    }
}

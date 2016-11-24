using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App2
{
    [Activity(Label = "App2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ObservableCollection<IBlock> list;
        string s;
        TextView txt;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button btnEndless = FindViewById<Button>(Resource.Id.button_endless);
            Button btnCondition = FindViewById<Button>(Resource.Id.button_condition);
            Button btnCounting = FindViewById<Button>(Resource.Id.button_counting);
            btnEndless.Click += delegate
            {
                EndlessLoop tmp = new EndlessLoop();
                list.Add(tmp);
            };
            btnCondition.Click += delegate
            {
                list.Add(new ConditionLoop());
            };
            btnCounting.Click += delegate
            {
                CountingLoop tmp = new CountingLoop();
                tmp.IsChild = true;
                list.Add(tmp);
            };
            list = new ObservableCollection<IBlock>();
            s = "";
            list.CollectionChanged += List_CollectionChanged;

            txt = FindViewById<TextView>(Resource.Id.text1);
            txt.Text = s;


        }
        public string blabla(ObservableCollection<IBlock> list)
        {
            int counter = 0;
            string result = "";
            foreach (IBlock block in list)
            {
                if (block.IsChild)
                {
                    result += "\n";
                    int tmp = counter;
                    while(tmp > 0)
                    {
                        result += "\t\t\t";
                        tmp--;
                    }
                    result += block.CodeText;
                    counter++;
                }
                else
                {
                    result += "\n";
                    while (counter > 0)
                    {
                        string s = "\t\t\t";
                        for (int i = counter-1; i > 0; i--)
                        {
                            s += s;

                        }
                        result += s + "}";
                        result += "\n";
                        counter--;
                    }
                    result += System.Environment.NewLine + "}" + System.Environment.NewLine + block.CodeText;
                    counter = 0;
                }
            }
            return result;
        }

        private void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //if (list[e.NewStartingIndex].GetType() == typeof(ConditionLoop))
            //{
            //    var tmp = (ConditionLoop)list[e.NewStartingIndex];
            //    tmp.Condition.Value = 5;
            ////}
            //txt.Text += string.Format("{0}{1}, {2}", System.Environment.NewLine, list[e.NewStartingIndex].Name, list[e.NewStartingIndex].Text);
            //txt.Text += string.Format("{0}{1}", System.Environment.NewLine, list[e.NewStartingIndex].CodeText);
            txt.Text = blabla(list);
        }
    }
}


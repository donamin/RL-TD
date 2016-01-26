using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PRL
{
    enum Action
    {
        ACT_TOP,
        ACT_BOTTOM,
        ACT_RIGHT,
        ACT_LEFT
    }

    public partial class Form1 : Form
    {
        //Unimportant variables
        Random rand;
        Color defaultBackColor;

        Cell[,] cells;
        Agent agent, enemy;

        int episodes = 0, wins = 0;
        List<int> lastEpisodesResults;
        int last100Wins = 0;

        public Form1()
        {
            InitializeComponent();
            InitCells();
            defaultBackColor = Color.FromArgb(240, 240, 240);
            rand = new Random();
            ResetAgents();
            lastEpisodesResults = new List<int>();
        }

        void InitCells()
        {
            cells = new Cell[5, 10];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 10; j++)
                    cells[i, j] = new Cell();
            cells[0, 0].bottom = cell_bottom_0;
            cells[0, 1].bottom = cell_bottom_1;
            cells[0, 2].bottom = cell_bottom_2;
            cells[0, 3].bottom = cell_bottom_3;
            cells[0, 4].bottom = cell_bottom_4;
            cells[0, 5].bottom = cell_bottom_5;
            cells[0, 6].bottom = cell_bottom_6;
            cells[0, 7].bottom = cell_bottom_7;
            cells[0, 8].bottom = cell_bottom_8;
            cells[0, 9].bottom = cell_bottom_9;
            cells[1, 0].bottom = cell_bottom_10;
            cells[1, 1].bottom = cell_bottom_11;
            cells[1, 2].bottom = cell_bottom_12;
            cells[1, 3].bottom = cell_bottom_13;
            cells[1, 4].bottom = cell_bottom_14;
            cells[1, 5].bottom = cell_bottom_15;
            cells[1, 6].bottom = cell_bottom_16;
            cells[1, 7].bottom = cell_bottom_17;
            cells[1, 8].bottom = cell_bottom_18;
            cells[1, 9].bottom = cell_bottom_19;
            cells[2, 0].bottom = cell_bottom_20;
            cells[2, 1].bottom = cell_bottom_21;
            cells[2, 2].bottom = cell_bottom_22;
            cells[2, 3].bottom = cell_bottom_23;
            cells[2, 4].bottom = cell_bottom_24;
            cells[2, 5].bottom = cell_bottom_25;
            cells[2, 6].bottom = cell_bottom_26;
            cells[2, 7].bottom = cell_bottom_27;
            cells[2, 8].bottom = cell_bottom_28;
            cells[2, 9].bottom = cell_bottom_29;
            cells[3, 0].bottom = cell_bottom_30;
            cells[3, 1].bottom = cell_bottom_31;
            cells[3, 2].bottom = cell_bottom_32;
            cells[3, 3].bottom = cell_bottom_33;
            cells[3, 4].bottom = cell_bottom_34;
            cells[3, 5].bottom = cell_bottom_35;
            cells[3, 6].bottom = cell_bottom_36;
            cells[3, 7].bottom = cell_bottom_37;
            cells[3, 8].bottom = cell_bottom_38;
            cells[3, 9].bottom = cell_bottom_39;
            cells[4, 0].bottom = cell_bottom_40;
            cells[4, 1].bottom = cell_bottom_41;
            cells[4, 2].bottom = cell_bottom_42;
            cells[4, 3].bottom = cell_bottom_43;
            cells[4, 4].bottom = cell_bottom_44;
            cells[4, 5].bottom = cell_bottom_45;
            cells[4, 6].bottom = cell_bottom_46;
            cells[4, 7].bottom = cell_bottom_47;
            cells[4, 8].bottom = cell_bottom_48;
            cells[4, 9].bottom = cell_bottom_49;
            ////////////////////////////////////
            cells[0, 0].top = cell_top_0;
            cells[0, 1].top = cell_top_1;
            cells[0, 2].top = cell_top_2;
            cells[0, 3].top = cell_top_3;
            cells[0, 4].top = cell_top_4;
            cells[0, 5].top = cell_top_5;
            cells[0, 6].top = cell_top_6;
            cells[0, 7].top = cell_top_7;
            cells[0, 8].top = cell_top_8;
            cells[0, 9].top = cell_top_9;
            cells[1, 0].top = cell_top_10;
            cells[1, 1].top = cell_top_11;
            cells[1, 2].top = cell_top_12;
            cells[1, 3].top = cell_top_13;
            cells[1, 4].top = cell_top_14;
            cells[1, 5].top = cell_top_15;
            cells[1, 6].top = cell_top_16;
            cells[1, 7].top = cell_top_17;
            cells[1, 8].top = cell_top_18;
            cells[1, 9].top = cell_top_19;
            cells[2, 0].top = cell_top_20;
            cells[2, 1].top = cell_top_21;
            cells[2, 2].top = cell_top_22;
            cells[2, 3].top = cell_top_23;
            cells[2, 4].top = cell_top_24;
            cells[2, 5].top = cell_top_25;
            cells[2, 6].top = cell_top_26;
            cells[2, 7].top = cell_top_27;
            cells[2, 8].top = cell_top_28;
            cells[2, 9].top = cell_top_29;
            cells[3, 0].top = cell_top_30;
            cells[3, 1].top = cell_top_31;
            cells[3, 2].top = cell_top_32;
            cells[3, 3].top = cell_top_33;
            cells[3, 4].top = cell_top_34;
            cells[3, 5].top = cell_top_35;
            cells[3, 6].top = cell_top_36;
            cells[3, 7].top = cell_top_37;
            cells[3, 8].top = cell_top_38;
            cells[3, 9].top = cell_top_39;
            cells[4, 0].top = cell_top_40;
            cells[4, 1].top = cell_top_41;
            cells[4, 2].top = cell_top_42;
            cells[4, 3].top = cell_top_43;
            cells[4, 4].top = cell_top_44;
            cells[4, 5].top = cell_top_45;
            cells[4, 6].top = cell_top_46;
            cells[4, 7].top = cell_top_47;
            cells[4, 8].top = cell_top_48;
            cells[4, 9].top = cell_top_49;
            ////////////////////////////////////
            cells[0, 0].left = cell_left_0;
            cells[0, 1].left = cell_left_1;
            cells[0, 2].left = cell_left_2;
            cells[0, 3].left = cell_left_3;
            cells[0, 4].left = cell_left_4;
            cells[0, 5].left = cell_left_5;
            cells[0, 6].left = cell_left_6;
            cells[0, 7].left = cell_left_7;
            cells[0, 8].left = cell_left_8;
            cells[0, 9].left = cell_left_9;
            cells[1, 0].left = cell_left_10;
            cells[1, 1].left = cell_left_11;
            cells[1, 2].left = cell_left_12;
            cells[1, 3].left = cell_left_13;
            cells[1, 4].left = cell_left_14;
            cells[1, 5].left = cell_left_15;
            cells[1, 6].left = cell_left_16;
            cells[1, 7].left = cell_left_17;
            cells[1, 8].left = cell_left_18;
            cells[1, 9].left = cell_left_19;
            cells[2, 0].left = cell_left_20;
            cells[2, 1].left = cell_left_21;
            cells[2, 2].left = cell_left_22;
            cells[2, 3].left = cell_left_23;
            cells[2, 4].left = cell_left_24;
            cells[2, 5].left = cell_left_25;
            cells[2, 6].left = cell_left_26;
            cells[2, 7].left = cell_left_27;
            cells[2, 8].left = cell_left_28;
            cells[2, 9].left = cell_left_29;
            cells[3, 0].left = cell_left_30;
            cells[3, 1].left = cell_left_31;
            cells[3, 2].left = cell_left_32;
            cells[3, 3].left = cell_left_33;
            cells[3, 4].left = cell_left_34;
            cells[3, 5].left = cell_left_35;
            cells[3, 6].left = cell_left_36;
            cells[3, 7].left = cell_left_37;
            cells[3, 8].left = cell_left_38;
            cells[3, 9].left = cell_left_39;
            cells[4, 0].left = cell_left_40;
            cells[4, 1].left = cell_left_41;
            cells[4, 2].left = cell_left_42;
            cells[4, 3].left = cell_left_43;
            cells[4, 4].left = cell_left_44;
            cells[4, 5].left = cell_left_45;
            cells[4, 6].left = cell_left_46;
            cells[4, 7].left = cell_left_47;
            cells[4, 8].left = cell_left_48;
            cells[4, 9].left = cell_left_49;
            ////////////////////////////////////
            cells[0, 0].right = cell_right_0;
            cells[0, 1].right = cell_right_1;
            cells[0, 2].right = cell_right_2;
            cells[0, 3].right = cell_right_3;
            cells[0, 4].right = cell_right_4;
            cells[0, 5].right = cell_right_5;
            cells[0, 6].right = cell_right_6;
            cells[0, 7].right = cell_right_7;
            cells[0, 8].right = cell_right_8;
            cells[0, 9].right = cell_right_9;
            cells[1, 0].right = cell_right_10;
            cells[1, 1].right = cell_right_11;
            cells[1, 2].right = cell_right_12;
            cells[1, 3].right = cell_right_13;
            cells[1, 4].right = cell_right_14;
            cells[1, 5].right = cell_right_15;
            cells[1, 6].right = cell_right_16;
            cells[1, 7].right = cell_right_17;
            cells[1, 8].right = cell_right_18;
            cells[1, 9].right = cell_right_19;
            cells[2, 0].right = cell_right_20;
            cells[2, 1].right = cell_right_21;
            cells[2, 2].right = cell_right_22;
            cells[2, 3].right = cell_right_23;
            cells[2, 4].right = cell_right_24;
            cells[2, 5].right = cell_right_25;
            cells[2, 6].right = cell_right_26;
            cells[2, 7].right = cell_right_27;
            cells[2, 8].right = cell_right_28;
            cells[2, 9].right = cell_right_29;
            cells[3, 0].right = cell_right_30;
            cells[3, 1].right = cell_right_31;
            cells[3, 2].right = cell_right_32;
            cells[3, 3].right = cell_right_33;
            cells[3, 4].right = cell_right_34;
            cells[3, 5].right = cell_right_35;
            cells[3, 6].right = cell_right_36;
            cells[3, 7].right = cell_right_37;
            cells[3, 8].right = cell_right_38;
            cells[3, 9].right = cell_right_39;
            cells[4, 0].right = cell_right_40;
            cells[4, 1].right = cell_right_41;
            cells[4, 2].right = cell_right_42;
            cells[4, 3].right = cell_right_43;
            cells[4, 4].right = cell_right_44;
            cells[4, 5].right = cell_right_45;
            cells[4, 6].right = cell_right_46;
            cells[4, 7].right = cell_right_47;
            cells[4, 8].right = cell_right_48;
            cells[4, 9].right = cell_right_49;
            ////////////////////////////////////
            cells[0, 0].cell = cell_0;
            cells[0, 1].cell = cell_1;
            cells[0, 2].cell = cell_2;
            cells[0, 3].cell = cell_3;
            cells[0, 4].cell = cell_4;
            cells[0, 5].cell = cell_5;
            cells[0, 6].cell = cell_6;
            cells[0, 7].cell = cell_7;
            cells[0, 8].cell = cell_8;
            cells[0, 9].cell = cell_9;
            cells[1, 0].cell = cell_10;
            cells[1, 1].cell = cell_11;
            cells[1, 2].cell = cell_12;
            cells[1, 3].cell = cell_13;
            cells[1, 4].cell = cell_14;
            cells[1, 5].cell = cell_15;
            cells[1, 6].cell = cell_16;
            cells[1, 7].cell = cell_17;
            cells[1, 8].cell = cell_18;
            cells[1, 9].cell = cell_19;
            cells[2, 0].cell = cell_20;
            cells[2, 1].cell = cell_21;
            cells[2, 2].cell = cell_22;
            cells[2, 3].cell = cell_23;
            cells[2, 4].cell = cell_24;
            cells[2, 5].cell = cell_25;
            cells[2, 6].cell = cell_26;
            cells[2, 7].cell = cell_27;
            cells[2, 8].cell = cell_28;
            cells[2, 9].cell = cell_29;
            cells[3, 0].cell = cell_30;
            cells[3, 1].cell = cell_31;
            cells[3, 2].cell = cell_32;
            cells[3, 3].cell = cell_33;
            cells[3, 4].cell = cell_34;
            cells[3, 5].cell = cell_35;
            cells[3, 6].cell = cell_36;
            cells[3, 7].cell = cell_37;
            cells[3, 8].cell = cell_38;
            cells[3, 9].cell = cell_39;
            cells[4, 0].cell = cell_40;
            cells[4, 1].cell = cell_41;
            cells[4, 2].cell = cell_42;
            cells[4, 3].cell = cell_43;
            cells[4, 4].cell = cell_44;
            cells[4, 5].cell = cell_45;
            cells[4, 6].cell = cell_46;
            cells[4, 7].cell = cell_47;
            cells[4, 8].cell = cell_48;
            cells[4, 9].cell = cell_49;
        }

        private void tickTimer_Tick(object sender, EventArgs e)
        {
            if (Won() || FellOnRocks() || HitEnemy())
            {
                ResetAgents();
                UpdateBackColors();
                return;
            }
            int x1 = agent.x, y1 = agent.y, ex1 = enemy.x, ey1 = enemy.y;
            float[] state = EncodeEnvironment();
            MakeAgentsMove(state, x1, y1, ex1, ey1);
            UpdateBackColors();
            float reward = 0;
            if (Won())
            {
                reward = 1;
                AddResult(true);
            }
            if (FellOnRocks())
            {
                reward = -1;
                AddResult(false);
            }
            if (HitEnemy())
            {
                reward = -1;
                AddResult(false);
            }
            if (chkTraining.Checked)
            {
                agent.Train(x1, y1, ex1, ey1, reward, agent.x, agent.y, enemy.x, enemy.y, chkEnemy.Checked, radioQLearning.Checked);
            }
            lblEpisodes.Text = "Episodes: " + episodes.ToString();
            lblWins.Text = "Wins: " + wins.ToString();
            lblLast100Wins.Text = "Last Wins: " + last100Wins + "/" + lastEpisodesResults.Count;
            UpdateDirections();
        }

        void UpdateDirections()
        {
            float[] state = EncodeEnvironment();
            if (state == null)
                return;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (y != 0 || x == 0)
                    {
                        List<float> q = agent.CalcQ(x, y, enemy.x, enemy.y, chkEnemy.Checked);
                        for (int a = 0; a < 4; a++)
                        {
                            int red = 255;
                            int green = 255;
                            int blue = 255;
                            q[a] = Math.Min(1, q[a]);
                            q[a] = Math.Max(-1, q[a]);
                            if (q[a] < 0)
                            {
                                green = 255 + (int)(q[a] * 255);
                                blue = 255 + (int)(q[a] * 255);
                            }
                            else
                            {
                                red = 255 - (int)(q[a] * 255);
                                blue = 255 - (int)(q[a] * 255);
                            }
                            switch (a)
                            {
                                case 0:
                                    cells[y, x].top.BackColor = Color.FromArgb(red, green, blue);
                                    break;
                                case 1:
                                    cells[y, x].right.BackColor = Color.FromArgb(red, green, blue);
                                    break;
                                case 2:
                                    cells[y, x].bottom.BackColor = Color.FromArgb(red, green, blue);
                                    break;
                                case 3:
                                    cells[y, x].left.BackColor = Color.FromArgb(red, green, blue);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        void AddResult(bool won)
        {
            optimal = false;
            episodes++;
            if (won)
                wins++;
            if (lastEpisodesResults.Count == 100)
            {
                last100Wins -= lastEpisodesResults[0];
                lastEpisodesResults.RemoveAt(0);
            }
            lastEpisodesResults.Add(won ? 1 : 0);
            last100Wins += lastEpisodesResults[lastEpisodesResults.Count - 1];
        }

        void UpdateBackColors()
        {
            for(int r = 0; r < 5; r++)
                for(int c = 0; c < 10; c++)
                {
                    if(r == 0 && c >= 1 && c <= 8)
                        cells[r, c].cell.BackColor = Color.DimGray;
                    else if(r == 0 && c == 9)
                        cells[r, c].cell.BackColor = Color.Purple;
                    else
                        cells[r, c].cell.BackColor = defaultBackColor;
                }
            cells[agent.y, agent.x].cell.BackColor = Color.Blue;
            if (chkEnemy.Checked)
            {
                cells[enemy.y, enemy.x].cell.BackColor = Color.Red;
                if (HitEnemy())
                    cells[enemy.y, enemy.x].cell.BackColor = Color.Orange;
            }
            if (Won())
                cells[agent.y, agent.x].cell.BackColor = Color.DeepPink;
            else if (FellOnRocks())
                cells[agent.y, agent.x].cell.BackColor = Color.Black;
        }

        void ResetAgents()
        {
            if (agent == null)
            {
                agent = new Agent();
                enemy = new Agent(true);
            }
            agent.x = agent.y = 0;
            enemy.x = rand.Next(0, 10);
            enemy.y = rand.Next(1, 5);
            cells[agent.y, agent.x].cell.BackColor = Color.Blue;
            cells[enemy.y, enemy.x].cell.BackColor = Color.Red;
        }

        void MakeAgentsMove(float[] state, int x, int y, int ex, int ey)
        {
            //First we move the agent.
            Action nextAction = Action.ACT_BOTTOM;
            if(optimal)
                nextAction = agent.GetTopRightAction();
            else
                nextAction = agent.GetNextAction(x, y, ex, ey, chkEnemy.Checked);
            switch (nextAction)
            {
                case Action.ACT_TOP:
                    if (agent.y > 0)
                        agent.y--;
                    break;
                case Action.ACT_BOTTOM:
                    if (agent.y < 4)
                        agent.y++;
                    break;
                case Action.ACT_RIGHT:
                    if (agent.x < 9)
                        agent.x++;
                    break;
                case Action.ACT_LEFT:
                    if (agent.x > 0)
                        agent.x--;
                    break;
            }
            if (chkEnemy.Checked)
            {
                //Now we move the enemy.
                switch (enemy.GetNextRandomAction())
                {
                    case Action.ACT_TOP:
                        if (enemy.y > 1 || (enemy.y == 1 && enemy.x == 0))
                            enemy.y--;
                        break;
                    case Action.ACT_BOTTOM:
                        if (enemy.y < 4)
                            enemy.y++;
                        break;
                    case Action.ACT_RIGHT:
                        if (enemy.y != 0 && enemy.x < 9)
                            enemy.x++;
                        break;
                    case Action.ACT_LEFT:
                        if (enemy.x > 0)
                            enemy.x--;
                        break;
                }
            }
        }

        bool Won()
        {
            return agent.y == 0 && agent.x == 9;
        }

        bool FellOnRocks()
        {
            if (agent.y == 0 && agent.x >= 1 && agent.x <= 8)
                return true;
            return false;
        }

        bool HitEnemy()
        {
            return chkEnemy.Checked && agent.x == enemy.x && agent.y == enemy.y;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (tickTimer.Enabled)
            {
                tickTimer.Stop();
                btnStart.Text = "Start";
            }
            else
            {
                tickTimer.Start();
                btnStart.Text = "Stop";
            }
            btnSave.Enabled = btnLoad.Enabled = !tickTimer.Enabled;
        }

        private void txtInterval_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tickTimer.Interval = int.Parse(txtInterval.Text);
            }
            catch(Exception ex)
            {
                txtInterval.Text = tickTimer.Interval.ToString();
            }
        }

        private void btnIncreaseEpsilon_Click(object sender, EventArgs e)
        {
            agent.epsilon = Math.Min(agent.epsilon + 0.05f, 1);
            lblEpsilon.Text = "ε = " + agent.epsilon.ToString("0.00");
        }

        private void btnDecreaseEpsilon_Click(object sender, EventArgs e)
        {
            agent.epsilon = Math.Max(agent.epsilon - 0.05f, 0);
            lblEpsilon.Text = "ε = " + agent.epsilon.ToString("0.00");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    sw.WriteLine(radioQLearning.Checked);
                    sw.WriteLine(radioSarsa.Checked);
                    sw.WriteLine(episodes);
                    sw.WriteLine(wins);
                    sw.WriteLine(last100Wins);
                    sw.WriteLine(lastEpisodesResults.Count);
                    for(int i = 0; i < lastEpisodesResults.Count; i++)
                        sw.WriteLine(lastEpisodesResults[i]);
                    sw.WriteLine(chkEnemy.Checked);
                    sw.WriteLine(chkTraining.Checked);
                    sw.WriteLine(agent.epsilon);
                    sw.WriteLine(tickTimer.Interval);
                    agent.SaveQTable(sw, chkEnemy.Checked);
                    MessageBox.Show("Network saved at " + saveFileDialog.FileName);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string message = "";
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog.FileName);
                    radioQLearning.Checked = bool.Parse(sr.ReadLine());
                    radioSarsa.Checked = bool.Parse(sr.ReadLine());
                    episodes = int.Parse(sr.ReadLine());
                    wins = int.Parse(sr.ReadLine());
                    last100Wins = int.Parse(sr.ReadLine());
                    lastEpisodesResults = new List<int>();
                    int count = int.Parse(sr.ReadLine());
                    for (int i = 0; i < count; i++)
                        lastEpisodesResults.Add(int.Parse(sr.ReadLine()));
                    chkEnemy.Checked = bool.Parse(sr.ReadLine());
                    chkTraining.Checked = bool.Parse(sr.ReadLine());
                    agent.epsilon = float.Parse(sr.ReadLine());
                    tickTimer.Interval = int.Parse(sr.ReadLine());
                    agent.LoadQTable(sr, chkEnemy.Checked);
                    sr.Close();
                    message = "Network loaded from " + openFileDialog.FileName;
                    UpdateDirections();
                }
                catch (Exception ex)
                {
                    radioQLearning.Checked = true;
                    radioSarsa.Checked = false;
                    episodes = 0;
                    last100Wins = 0;
                    lastEpisodesResults = new List<int>();
                    chkEnemy.Checked = true;
                    tickTimer.Interval = 100;
                    agent.epsilon = 0.2f;
                    message = ex.Message;
                }
                lblEpisodes.Text = "Episodes: " + episodes.ToString();
                lblWins.Text = "Wins: " + wins.ToString();
                lblLast100Wins.Text = "Last Wins: " + last100Wins + "/" + lastEpisodesResults.Count;
                txtInterval.Text = tickTimer.Interval.ToString();
                lblEpsilon.Text = "ε = " + agent.epsilon.ToString("0.00");
                MessageBox.Show(message);
            }
        }

        private void chkEnemy_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkEnemy.Checked)
            {
                cells[enemy.y, enemy.x].cell.BackColor = defaultBackColor;
            }
            else
            {
                cells[enemy.y, enemy.x].cell.BackColor = Color.Red;
            }
        }

        float[] EncodeEnvironment()
        {
            if (agent.y == 0 && agent.x > 0)
                return null;
            float[] result;
            if (chkEnemy.Checked)
            {
                if (agent.x == enemy.x && agent.y == enemy.y)
                    return null;
                result = new float[5];
                //Player
                result[0] = EncodeX(agent.x);
                result[1] = EncodeY(agent.y);
                //Enemy
                result[2] = EncodeX(enemy.x);
                result[3] = EncodeY(enemy.y);
                result[4] = 1; //Bias
                return result;
            }
            result = new float[3];
            //Player
            result[0] = EncodeX(agent.x);
            result[1] = EncodeY(agent.y);
            result[2] = 1; //Bias
            return result;
        }

        float EncodeX(int x)
        {
            return (x / 4.5f) - 1;
        }

        float EncodeY(int y)
        {
            return (y / 2.0f) - 1;
        }

        bool optimal = false;
        private void btnOptimal_Click(object sender, EventArgs e)
        {
            optimal = true;
        }
    }
}

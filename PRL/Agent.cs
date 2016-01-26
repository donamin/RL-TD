using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRL
{
    struct Transition
    {
        public float[] curState, nextState;
        public int action;
        public float reward;
    };

    class Agent
    {
        Random random;
        public int x, y;
        public float epsilon = 0.2f;
        public int lastChosenAction;
        float[,,] qTable_NoEnemy;
        float[,,,,] qTable_Enemy;

        public Agent(bool enemy = false)
        {
            if(enemy)
                random = new Random(DateTime.Now.Millisecond % DateTime.Now.Second);
            else
                random = new Random(DateTime.Now.Millisecond);
            qTable_NoEnemy = new float[5, 10, 4];
            qTable_Enemy = new float[5, 10, 5, 10, 4];
        }

        public void SaveQTable(StreamWriter writer, bool withEnemy)
        {
            if (withEnemy)
            {
                for (int y = 0; y < 5; y++)
                    for (int x = 0; x < 10; x++)
                        for (int ey = 0; ey < 5; ey++)
                            for (int ex = 0; ex < 10; ex++)
                                for (int a = 0; a < 4; a++)
                            writer.WriteLine(qTable_Enemy[y, x, ey, ex, a]);
            }
            else
            {
                for (int y = 0; y < 5; y++)
                    for (int x = 0; x < 10; x++)
                        for (int a = 0; a < 4; a++)
                            writer.WriteLine(qTable_NoEnemy[y, x, a]);
            }
        }

        public void LoadQTable(StreamReader reader, bool withEnemy)
        {
            if (withEnemy)
            {
                for (int y = 0; y < 5; y++)
                    for (int x = 0; x < 10; x++)
                        for (int ey = 0; ey < 5; ey++)
                            for (int ex = 0; ex < 10; ex++)
                                for (int a = 0; a < 4; a++)
                                    qTable_Enemy[y, x, ey, ex, a] = float.Parse(reader.ReadLine());
            }
            else
            {
                for (int y = 0; y < 5; y++)
                    for (int x = 0; x < 10; x++)
                        for (int a = 0; a < 4; a++)
                            qTable_NoEnemy[y, x, a] = float.Parse(reader.ReadLine());
            }
        }

        public void Train(int x1, int y1, int ex1, int ey1, float reward, int x2, int y2, int ex2, int ey2, bool withEnemy, bool qLearning)
        {
            float nextQ = 0;
            if (reward < 0.99f && reward > -0.99f)
            {
                if (qLearning || random.NextDouble() > epsilon)
                {
                    if (withEnemy)
                    {
                        nextQ = qTable_Enemy[y2, x2, ey2, ex2, 0];
                        for (int i = 1; i < 4; i++)
                            if (qTable_Enemy[y2, x2, ey2, ex2, i] > nextQ)
                                nextQ = qTable_Enemy[y2, x2, ey2, ex2, i];
                    }
                    else
                    {
                        nextQ = qTable_NoEnemy[y2, x2, 0];
                        for (int i = 1; i < 4; i++)
                            if (qTable_NoEnemy[y2, x2, i] > nextQ)
                                nextQ = qTable_NoEnemy[y2, x2, i];
                    }
                }
                else
                {
                    if (withEnemy)
                        nextQ = qTable_Enemy[y2, x2, ey2, ex2, random.Next(0, 4)];
                    else
                        nextQ = qTable_NoEnemy[y2, x2, random.Next(0, 4)];
                }
            }
            float estimation = reward + 0.9f * nextQ;
            if (withEnemy)
            {
                qTable_Enemy[y1, x1, ey1, ex1, lastChosenAction] += 0.1f * (estimation - qTable_Enemy[y1, x1, ey1, ex1, lastChosenAction]);
            }
            else
            {
                qTable_NoEnemy[y1, x1, lastChosenAction] += 0.1f * (estimation - qTable_NoEnemy[y1, x1, lastChosenAction]);
            }
        }

        public List<float> CalcQ(int x, int y, int ex, int ey, bool withEnemy)
        {
            List<float> result = new List<float>();
            for (int a = 0; a < 4; a++)
            {
                if (withEnemy)
                    result.Add(qTable_Enemy[y, x, ey, ex, a]);
                else
                    result.Add(qTable_NoEnemy[y, x, a]);
            }
            return result;
        }

        public Action GetNextAction(int x, int y, int ex, int ey, bool withEnemy)
        {
            lastChosenAction = random.Next(0, 4);
            if (random.NextDouble() > epsilon)
            {
                if (withEnemy)
                {
                    for (int i = 1; i < 4; i++)
                        if (qTable_Enemy[y, x, ey, ex, i] > qTable_Enemy[y, x, ey, ex, lastChosenAction])
                            lastChosenAction = i;
                }
                else
                {
                    for (int i = 1; i < 4; i++)
                        if (qTable_NoEnemy[y, x, i] > qTable_NoEnemy[y, x, lastChosenAction])
                            lastChosenAction = i;
                }
            }
            switch (lastChosenAction)
            {
                case 0:
                    return Action.ACT_TOP;
                case 1:
                    return Action.ACT_RIGHT;
                case 2:
                    return Action.ACT_BOTTOM;
                case 3:
                    return Action.ACT_LEFT;
            }
            return GetNextRandomAction();
        }

        public Action GetNextRandomAction()
        {
            lastChosenAction = random.Next(0, 4);
            switch (lastChosenAction)
            {
                case 0:
                    return Action.ACT_TOP;
                case 1:
                    return Action.ACT_RIGHT;
                case 2:
                    return Action.ACT_BOTTOM;
                case 3:
                    return Action.ACT_LEFT;
            }
            return Action.ACT_BOTTOM;
        }

        public Action GetTopRightAction()
        {
            if(x == 0 && y == 0)
                lastChosenAction = 2;
            else if (x < 9)
                lastChosenAction = 1;
            else
                lastChosenAction = 0;
            switch (lastChosenAction)
            {
                case 0:
                    return Action.ACT_TOP;
                case 1:
                    return Action.ACT_RIGHT;
                case 2:
                    return Action.ACT_BOTTOM;
            }
            return Action.ACT_LEFT;
        }
    }
}
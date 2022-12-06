namespace adventofcode
{
    /**
    * Advent of code Day 2
    */
    class Program
    {

        private int totalscore;

        private enum OutcomeOfTheRound
        {
            outcome_lost = 0,
            outcome_draw = 3,
            outcome_won = 6
        }

        private void Init()
        {
            totalscore = 0;
        }

        /* 
            A & X = rock = 1p
            B & Y = paper = 2p
            C & Z = scissor = 3p
        */
        private void GetTotalScore(char p1, char p2)
        {
            int p1_value = 0;
            int p2_value = 0;
            int p2_outcomeValue = 0;

            switch(p1)
            {
                case 'A':
                    p1_value = 1;
                    switch(p2)
                    {
                        case 'X':
                            p2_value = 1;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_draw;
                            break;
                        case 'Y':
                            p2_value = 2;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_won;
                            break;
                        case 'Z':
                            p2_value = 3;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_lost;
                            break;
                        default:
                            Console.WriteLine("Error getting p2.");
                            break;
                    }
                    totalscore += p2_value + p2_outcomeValue;
                    break;
                case 'B':
                    p1_value = 2;
                    switch(p2)
                    {
                        case 'X':
                            p2_value = 1;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_lost;
                            break;
                        case 'Y':
                            p2_value = 2;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_draw;
                            break;
                        case 'Z':
                            p2_value = 3;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_won;
                            break;
                        default:
                            Console.WriteLine("Error getting p2.");
                            break;
                    }
                    totalscore += p2_value + p2_outcomeValue;
                    break;
                case 'C':
                    p1_value = 3;
                    switch(p2)
                    {
                        case 'X':
                            p2_value = 1;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_won;
                            break;
                        case 'Y':
                            p2_value = 2;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_lost;
                            break;
                        case 'Z':
                            p2_value = 3;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_draw;
                            break;
                        default:
                            Console.WriteLine("Error getting p2.");
                            break;
                    }
                    totalscore += p2_value + p2_outcomeValue;
                    break;
                default:
                    Console.WriteLine("Error getting p1.");
                    break;
            }
        }

        /* 
            A = rock = 1p
            B = paper = 2p
            C = scissor = 3p

            X = need to lose
            Y = need to end in draw
            Z = need to win
        */
        private void GetTotalScoreDecryptedVersion(char p1, char p2)
        {
            int p1_value = 0;
            int p2_value = 0;
            int p2_outcomeValue = 0;

            switch(p1)
            {
                case 'A':
                    p1_value = 1;
                    switch(p2)
                    {
                        case 'X':
                            p2_value = 3;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_lost;
                            break;
                        case 'Y':
                            p2_value = 1;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_draw;
                            break;
                        case 'Z':
                            p2_value = 2;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_won;
                            break;
                        default:
                            Console.WriteLine("Error getting p2.");
                            break;
                    }
                    totalscore += p2_value + p2_outcomeValue;
                    break;
                case 'B':
                    p1_value = 2;
                    switch(p2)
                    {
                        case 'X':
                            p2_value = 1;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_lost;
                            break;
                        case 'Y':
                            p2_value = 2;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_draw;
                            break;
                        case 'Z':
                            p2_value = 3;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_won;
                            break;
                        default:
                            Console.WriteLine("Error getting p2.");
                            break;
                    }
                    totalscore += p2_value + p2_outcomeValue;
                    break;
                case 'C':
                    p1_value = 3;
                    switch(p2)
                    {
                        case 'X':
                            p2_value = 2;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_lost;
                            break;
                        case 'Y':
                            p2_value = 3;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_draw;
                            break;
                        case 'Z':
                            p2_value = 1;
                            p2_outcomeValue =(int) OutcomeOfTheRound.outcome_won;
                            break;
                        default:
                            Console.WriteLine("Error getting p2.");
                            break;
                    }
                    totalscore += p2_value + p2_outcomeValue;
                    break;
                default:
                    Console.WriteLine("Error getting p1.");
                    break;
            }
        }

        // Part 1
        private void PlayRounds()
        {
            Init();
            
            foreach (string line in File.ReadLines("puzzleinput.txt"))
            {  
                char p1 = line[0];
                char p2 = line[2];
                GetTotalScore(p1, p2);
            }

             Console.WriteLine("Total score: {0}.", totalscore);  
        }


        // Part 2
        private void PlayRoundsDecryptedVersion()
        {
            Init();
            
            foreach (string line in File.ReadLines("puzzleinput.txt"))
            {  
                char p1 = line[0];
                char p2 = line[2];
                GetTotalScoreDecryptedVersion(p1, p2);
            }

             Console.WriteLine("Total score DECRYPTED: {0}.", totalscore);  
        }


        static void Main ()
        {
            Program p = new Program();
            p.PlayRounds();
            p.PlayRoundsDecryptedVersion();
        }
    }
}

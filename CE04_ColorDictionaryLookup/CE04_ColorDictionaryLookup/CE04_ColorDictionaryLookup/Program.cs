using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CE04_ColorDictionaryLookup
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> ColorDictionary = new Dictionary<string, string>() {};

            //Add red facts to dictionary
            ColorDictionary.Add("red1", "Red doesn't make bulls angry; they are color-blind");
            ColorDictionary.Add("red2", "The Red stripes on the United States flag stand for courage");
            ColorDictionary.Add("red3", "The word \"ruby\" comes from the Latin word rubens, meaning \"Red\"");
            //Add Orange facts to dictionary
            ColorDictionary.Add("orange1", "The term ‘orange’, first used in the early 1500s, was taken directly from the\r\n           Old French word ‘orenge’ in reference to the fruit of the same colour and\r\n           name, while previously the colour was known as ‘ġeolurēad‘ which literally\r\n           meant ‘yellow-red’.");
            ColorDictionary.Add("orange2", "It is widely accepted that there is no single English word is a true rhyme for\r\n           orange");
            ColorDictionary.Add("orange3", "\"Safety orange\" is used to set objects apart from their surroundings,\r\n           particularly in complementary contrast to the azure color of the sky");
            //Add Yellow facts to dictionary
            ColorDictionary.Add("yellow1", "The color yellow can cause nausea");
            ColorDictionary.Add("yellow2", "Pure bright yellow is believed to be the most irritating color due to its\r\n           excessive stimulation to the eye");
            ColorDictionary.Add("yellow3", "During the tenth century in France, the doors of traitors and criminals were\r\n           painted yellow");
            //Add Green facts to dictionary
            ColorDictionary.Add("green1", "In the 19th century Scheele's Green was extremely popular, a vibrant pigment\r\n           used for wallpapers, candles, home-goods, clothes, and even confections but\r\n           contained arsenic and lead to the deaths of children (and possibly Napoleon)");
            ColorDictionary.Add("green2", "Traffic lights are green all over the world");
            ColorDictionary.Add("green3", "Green is the second most popular favorite color, after blue");
            //Add Blue facts to dictionary
            ColorDictionary.Add("blue1", "Early use of blue paint was so highly prized that laws existed as to what\r\n           artists were allowed to paint blue. Jesus and Mary’s robes were usually the\r\n           only accepted uses of the precious color");
            ColorDictionary.Add("blue2", "Research shows that mosquitoes are attracted to dark colors especially blue");
            ColorDictionary.Add("blue3", "8% of the worlds population has blue eyes");
            //Add Indigo facts to dictionary
            ColorDictionary.Add("indigo1", "The color indigo is named after the indigo dye derived from the plant\r\n           Indigofera tinctoria");
            ColorDictionary.Add("indigo2", "It is recorded as far back as 1229 in English history that “Indigo” was used\r\n           as a color name");
            ColorDictionary.Add("indigo3", "Isaac Newton introduced indigo as one of the seven base colors of his work\r\n           (ROY G BIV)");
            //Add Vilet facts to dictionary
            ColorDictionary.Add("violet1", "Leonardo da Vinci said that the power of meditation can be 10 times greater\r\n           under the violet light falling through the stained glass windows of a quiet\r\n           church");
            ColorDictionary.Add("violet2", "Violet is used to point out the danger of atomic radiation");
            ColorDictionary.Add("violet3", "Too much of the color violet can hinder conversation and promote indulgence");

            Headers.Header("");

            bool programIsRunning = true;

            while (programIsRunning) {

                string input = Headers.SelectionOptions(" Select your favorite color: ");

                switch (input) {

                    //Red selection
                    case "1":
                    case "red": {                         
                            Headers.Next(ColorDictionary["red1"], ColorDictionary["red2"], ColorDictionary["red3"], "Red");
                        } break;

                    //Orange selection       
                    case "2":
                    case "orange": {
                            Headers.Next(ColorDictionary["orange1"], ColorDictionary["orange2"], ColorDictionary["orange3"], "Orange");
                        }
                        break;

                    //Yellow selection
                    case "3":
                    case "yellow": {
                            Headers.Next(ColorDictionary["yellow1"], ColorDictionary["yellow2"], ColorDictionary["yellow3"], "Yellow");

                        }
                        break;

                    //Green selection
                    case "4":
                    case "green":  {
                            Headers.Next(ColorDictionary["green1"], ColorDictionary["green2"], ColorDictionary["green3"], "Green");

                        }  break;

                    //Blue selection
                    case "5":
                    case "blue": {
                            Headers.Next(ColorDictionary["blue1"], ColorDictionary["blue2"], ColorDictionary["blue3"], "Blue");
                        }  break;

                    //Indigo selection
                    case "6":
                    case "indigo": {
                            Headers.Next(ColorDictionary["indigo1"], ColorDictionary["indigo2"], ColorDictionary["indigo3"], "Indigo");
                        } break;

                    //Vilet selection
                    case "7":
                    case "violet": {
                            Headers.Next(ColorDictionary["violet1"], ColorDictionary["violet2"], ColorDictionary["violet3"], "Violet");
                        } break;

                    case "0": {
                            programIsRunning = false;
                        } break;
                }
            }
        }
    }
}

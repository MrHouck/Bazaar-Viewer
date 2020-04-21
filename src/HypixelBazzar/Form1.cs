using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace HypixelBazzar
{
    public partial class Form1 : Form
    {
        public string api_key;
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
        }

        private bool ValidateApiKey()
        {
            api_key = this.textBox1.Text;
            string json = string.Empty;
            string url = @"https://api.hypixel.net/skyblock/bazaar?key=" + api_key;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
            } catch(WebException)
            {
                return false;
            }
            dynamic parsed = JObject.Parse(json);
            if (parsed.success == true)
                return true;
            else
                return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label3.Visible = false;
            panelSideMenu.Visible = false;
            panelSideMenu.Enabled = false;
            panelItemType.Enabled = false;
            panelItemType.Visible = false;
            labelInvalidKey.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            linkLabel1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
            ToolTip t_Tip = new ToolTip();
            t_Tip.Active = true;
            t_Tip.AutoPopDelay = 4000;
            t_Tip.IsBalloon = true;
            t_Tip.ToolTipIcon = ToolTipIcon.None;
            t_Tip.SetToolTip(labelApiQuestion, "You can generate an API key by typing /api in game");
        }

        private void btnSubmitKey_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateApiKey();
            if(!isValid)
            {
                labelInvalidKey.Visible = true;
            }
            if(isValid && labelInvalidKey.Visible)
            {
                labelInvalidKey.Visible = false;
                Valid();
            }
            else if(isValid)
            {
                Valid();
            }
        }
        private void Valid()
        {
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = true;
            label4.Visible = true;
            linkLabel1.Visible = true;
            textBox1.Enabled = false;
            textBox1.Visible = false;
            panelSideMenu.Visible = true;
            panelSideMenu.Enabled = true;
            btnSubmitKey.Visible = false;
            btnSubmitKey.Enabled = false;
            labelApiQuestion.Visible = false;
            panelItemType.Enabled = true;
            panelItemType.Visible = true;
            pictureBox2.Visible = true;
            pictureBox1.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
        }

        private void customizeDesign()
        {
            panelFarmingSubmenu.Visible = false;
            panelMiningSubmenu.Visible = false;
            panelCombatSidemenu.Visible = false;
            panelWoodFishSidemenu.Visible = false;
            panelOdditiesSidemenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if (panelFarmingSubmenu.Visible)
                panelFarmingSubmenu.Visible = false;
            if (panelMiningSubmenu.Visible)
                panelMiningSubmenu.Visible = false;
            if (panelCombatSidemenu.Visible)
                panelCombatSidemenu.Visible = false;
            if (panelWoodFishSidemenu.Visible)
                panelWoodFishSidemenu.Visible = false;
            if (panelOdditiesSidemenu.Visible)
                panelOdditiesSidemenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        #region Farming
        private void btnFarming_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFarmingSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //wheat, enchanted bread, haybale, enchanted haybale
            btnItemVariant1.BackgroundImage = Properties.Resources.wheat;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_bread;
            btnItemVariant3.BackgroundImage = Properties.Resources.hay_bale;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_hay_bale;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "WHEAT";
            btnItemVariant2.Tag = "ENCHANTED_BREAD";
            btnItemVariant3.Tag = "HAY_BLOCK";
            btnItemVariant4.Tag = "ENCHANTED_HAY_BLOCK";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //carrot, enchanted carrot, enchanted carrot on a stick, enchanted golden carrot
            btnItemVariant1.BackgroundImage = Properties.Resources.carrot;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_carrot;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_carrot_on_a_stick;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_golden_carrot;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "CARROT_ITEM";
            btnItemVariant2.Tag = "ENCHANTED_CARROT";
            btnItemVariant3.Tag = "ENCHANTED_CARROT_ON_A_STICK";
            btnItemVariant4.Tag = "ENCHANTED_GOLDEN_CARROT";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //potato, enchanted potato, enchanted baked potato
            btnItemVariant1.BackgroundImage = Properties.Resources.potato;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_potato;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_baked_potato;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "POTATO_ITEM";
            btnItemVariant2.Tag = "ENCHANTED_POTATO";
            btnItemVariant3.Tag = "ENCHANTED_HOT_POTATO";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //pumpkin, enchanted pumpkin
            btnItemVariant1.BackgroundImage = Properties.Resources.pumpkin;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_pumpkin;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "PUMPKIN";
            btnItemVariant2.Tag = "ENCHANTED_PUMPKIN";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //melon, enchanted melon, enchanted glist melon, enchanted melon block
            btnItemVariant1.BackgroundImage = Properties.Resources.melon;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_melon;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_glistering_melon;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_melon_block;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "MELON";
            btnItemVariant2.Tag = "ENCHANTED_MELON";
            btnItemVariant3.Tag = "ENCHANTED_GLISTERING_MELON";
            btnItemVariant4.Tag = "ENCHANTED_MELON_BLOCK";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //seeds, ench seeds
            btnItemVariant1.BackgroundImage = Properties.Resources.seeds;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_seeds;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SEEDS";
            btnItemVariant2.Tag = "ENCHANTED_SEEDS";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //red mushroom, ench red mush, red mush block, ench red mush block
            btnItemVariant1.BackgroundImage = Properties.Resources.red_mushroom;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_red_mushroom;
            btnItemVariant3.BackgroundImage = Properties.Resources.red_mushroom_block;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_red_mushroom_block;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "RED_MUSHROOM";
            btnItemVariant2.Tag = "ENCHANTED_RED_MUSHROOM";
            btnItemVariant3.Tag = "HUGE_MUSHROOM_1";
            btnItemVariant4.Tag = "ENCHANTED_HUGE_MUSHROOM_1";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //brown mushrooms, ench brown mush, brown mush block, ench brown mush block
            btnItemVariant1.BackgroundImage = Properties.Resources.brown_mushroom;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_brown_mushroom;
            btnItemVariant3.BackgroundImage = Properties.Resources.brown_mushroom_block;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_brown_mushroom_block;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "BROWN_MUSHROOM";
            btnItemVariant2.Tag = "ENCHANTED_BROWN_MUSHROOM";
            btnItemVariant3.Tag = "HUGE_MUSHROOM_2";
            btnItemVariant4.Tag = "ENCHANTED_HUGE_MUSHROOM_2";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //cocoa beans, ench c beans, ench cookie
            btnItemVariant1.BackgroundImage = Properties.Resources.cocoa_bean;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_cocoa_bean;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_cookie;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "INK_SACK:3";
            btnItemVariant2.Tag = "ENCHANTED_COCOA";
            btnItemVariant3.Tag = "ENCHANTED_COOKIE";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //cactus, ench cac green, ench cac
            btnItemVariant1.BackgroundImage = Properties.Resources.cactus;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_cactus_green;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_cactus;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "CACTUS";
            btnItemVariant2.Tag = "ENCHANTED_CACTUS_GREEN";
            btnItemVariant3.Tag = "ENCHANTED_CACTUS";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //sugarcane, ench sugar, ench paper, ench cane
            btnItemVariant1.BackgroundImage = Properties.Resources.sugar_cane;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_sugar;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_paper;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_sugar_cane;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SUGAR_CANE";
            btnItemVariant2.Tag = "ENCHANTED_SUGAR";
            btnItemVariant3.Tag = "ENCHANTED_PAPER";
            btnItemVariant4.Tag = "ENCHANTED_SUGAR_CANE";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //feather, ench feather
            btnItemVariant1.BackgroundImage = Properties.Resources.feather;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_feather;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "FEATHER";
            btnItemVariant2.Tag = "ENCHANTED_FEATHER";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //leather and beef
            btnItemVariant1.BackgroundImage = Properties.Resources.leather;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_leather;
            btnItemVariant3.BackgroundImage = Properties.Resources.raw_beef;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_raw_beef;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "LEATHER";
            btnItemVariant2.Tag = "ENCHANTED_LEATHER";
            btnItemVariant3.Tag = "RAW_BEEF";
            btnItemVariant4.Tag = "ENCHANTED_RAW_BEEF";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //pork, ench pork, ench grill pork
            btnItemVariant1.BackgroundImage = Properties.Resources.raw_porkchop;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_pork;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_grilled_pork;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "PORK";
            btnItemVariant2.Tag = "ENCHANTED_PORK";
            btnItemVariant3.Tag = "ENCHANTED_GRILLED_PORK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //chicken, ench raw chick, ench egg, ench cake, super ench egg
            btnItemVariant1.BackgroundImage = Properties.Resources.raw_chicken;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_raw_chicken;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_egg;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_cake;
            btnItemVariant5.BackgroundImage = Properties.Resources.super_enchanted_egg;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "RAW_CHICKEN";
            btnItemVariant2.Tag = "ENCHANTED_RAW_CHICKEN";
            btnItemVariant3.Tag = "ENCHANTED_EGG";
            btnItemVariant4.Tag = "ENCHANTED_CAKE";
            btnItemVariant5.Tag = "SUPER_ENCHANTED_EGG";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //mutton, ench mutton, ench cooked mutton
            btnItemVariant1.BackgroundImage = Properties.Resources.mutton;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_mutton;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_cooked_mutton;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "MUTTON";
            btnItemVariant2.Tag = "ENCHANTED_MUTTON";
            btnItemVariant3.Tag = "ENCHANTED_COOKED_MUTTON";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //rabbit, ench raw rab, rab foot, rab hide, ench rab foot, ench rab hide
            btnItemVariant1.BackgroundImage = Properties.Resources.raw_rabbit;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_raw_rabbit;
            btnItemVariant3.BackgroundImage = Properties.Resources.rabbit_foot;
            btnItemVariant4.BackgroundImage = Properties.Resources.rabbit_hide;
            btnItemVariant5.BackgroundImage = Properties.Resources.enchanted_rabbit_foot;
            btnItemVariant6.BackgroundImage = Properties.Resources.enchanted_rabbit_hide;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "RABBIT";
            btnItemVariant2.Tag = "ENCHANTED_RABBIT";
            btnItemVariant3.Tag = "RABBIT_FOOT";
            btnItemVariant4.Tag = "RABBIT_HIDE";
            btnItemVariant5.Tag = "ENCHANTED_RABBIT_FOOT";
            btnItemVariant6.Tag = "ENCHANTED_RABBIT_HIDE";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //nether warts, ench neth wart
            btnItemVariant1.BackgroundImage = Properties.Resources.nether_wart;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_nether_wart;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "NETHER_STALK";
            btnItemVariant2.Tag = "ENCHANTED_NETHER_STALK";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }
        #endregion Farming
        #region Mining
        private void btnMining_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMiningSubmenu);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //cobblestone, ench cob
            btnItemVariant1.BackgroundImage = Properties.Resources.cobblestone;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_cobblestone;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "COBBLESTONE";
            btnItemVariant2.Tag = "ENCHANTED_COBBLESTONE";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //coal, ench coal, ench charc, ench coal bloc
            btnItemVariant1.BackgroundImage = Properties.Resources.coal;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_coal;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_charcoal;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_block_of_coal;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "COAL";
            btnItemVariant2.Tag = "ENCHANTED_COAL";
            btnItemVariant3.Tag = "ENCHANTED_CHARCOAL";
            btnItemVariant4.Tag = "ENCHANTED_COAL_BLOCK";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //iron, ench iron, ench iron block
            btnItemVariant1.BackgroundImage = Properties.Resources.iron_ingot;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_iron;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_iron_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "IRON_INGOT";
            btnItemVariant2.Tag = "ENCHANTED_IRON";
            btnItemVariant3.Tag = "ENCHANTED_IRON_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //gold, ench gold, ench gold block
            btnItemVariant1.BackgroundImage = Properties.Resources.gold_ingot;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_gold;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_gold_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "GOLD_INGOT";
            btnItemVariant2.Tag = "ENCHANTED_GOLD";
            btnItemVariant3.Tag = "ENCHANTED_GOLD_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //diamond
            // i give up on listing every variant its just waste of time
            btnItemVariant1.BackgroundImage = Properties.Resources.diamond;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_diamond;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_diamond_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "DIAMOND";
            btnItemVariant2.Tag = "ENCHANTED_DIAMOND";
            btnItemVariant3.Tag = "ENCHANTED_DIAMOND_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //lapis
            btnItemVariant1.BackgroundImage = Properties.Resources.lapis_lazuli;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_lapis_lazuli;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_lapis_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "INK_SACK:4";
            btnItemVariant2.Tag = "ENCHANTED_LAPIS_LAZULI";
            btnItemVariant3.Tag = "ENCHANTED_LAPIS_LAZULI_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //emerald
            btnItemVariant1.BackgroundImage = Properties.Resources.emerald;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_emerald;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_emerald_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "EMERALD";
            btnItemVariant2.Tag = "ENCHANTED_EMERALD";
            btnItemVariant3.Tag = "ENCHANTED_EMERALD_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //redstone
            btnItemVariant1.BackgroundImage = Properties.Resources.redstone;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_redstone;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_redstone_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "REDSTONE";
            btnItemVariant2.Tag = "ENCHANTED_REDSTONE";
            btnItemVariant3.Tag = "ENCHANTED_REDSTONE_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //quartz
            btnItemVariant1.BackgroundImage = Properties.Resources.nether_quartz;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_quartz;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_quartz_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "QUARTZ";
            btnItemVariant2.Tag = "ENCHANTED_QUARTZ";
            btnItemVariant3.Tag = "ENCHANTED_QUARTZ_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //obsdian
            btnItemVariant1.BackgroundImage = Properties.Resources.obsidian;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_obsidian;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "OBSIDIAN";
            btnItemVariant2.Tag = "ENCHANTED_OBSIDIAN";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            //glowstone
            btnItemVariant1.BackgroundImage = Properties.Resources.glowstone_dust;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_glowstone_dust;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_glowstone;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "GLOWSTONE_DUST";
            btnItemVariant2.Tag = "ENCHANTED_GLOWSTONE_DUST";
            btnItemVariant3.Tag = "ENCHANTED_GLOWSTONE";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //gravel
            btnItemVariant1.BackgroundImage = Properties.Resources.gravel;
            btnItemVariant2.BackgroundImage = Properties.Resources._null;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "GRAVEL";
            btnItemVariant2.Tag = "";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //flint
            btnItemVariant1.BackgroundImage = Properties.Resources.flint;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_flint;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "FLINT";
            btnItemVariant2.Tag = "ENCHANTED_FLINT";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //ice
            btnItemVariant1.BackgroundImage = Properties.Resources.ice;
            btnItemVariant2.BackgroundImage = Properties.Resources.packed_ice;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_ice;
            btnItemVariant4.BackgroundImage = Properties.Resources.enchanted_packed_ice;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "ICE";
            btnItemVariant2.Tag = "PACKED_ICE";
            btnItemVariant3.Tag = "ENCHANTED_ICE";
            btnItemVariant4.Tag = "ENCHANTED_PACKED_ICE";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //netherrack
            btnItemVariant1.BackgroundImage = Properties.Resources.netherrack;
            btnItemVariant2.BackgroundImage = Properties.Resources._null;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "NETHERRACK";
            btnItemVariant2.Tag = "";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //sand
            btnItemVariant1.BackgroundImage = Properties.Resources.sand;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_sand;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SAND";
            btnItemVariant2.Tag = "ENCHANTED_SAND";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //end stone
            btnItemVariant1.BackgroundImage = Properties.Resources.end_stone;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_end_stone;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "ENDER_STONE";
            btnItemVariant2.Tag = "ENCHANTED_END_STONE";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //snow
            btnItemVariant1.BackgroundImage = Properties.Resources.snowball;
            btnItemVariant2.BackgroundImage = Properties.Resources.snow_block;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_snow_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SNOW_BALL";
            btnItemVariant2.Tag = "SNOW_BLOCK";
            btnItemVariant3.Tag = "ENCHANTED_SNOW_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }
        #endregion Mining
        #region Combat
        private void btnCombat_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCombatSidemenu);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            //rotten flesh
            btnItemVariant1.BackgroundImage = Properties.Resources.rotten_flesh;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_rotten_flesh;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "ROTTEN_FLESH";
            btnItemVariant2.Tag = "ENCHANTED_ROTTEN_FLESH";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            //bone
            btnItemVariant1.BackgroundImage = Properties.Resources.bone;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_bone;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "BONE";
            btnItemVariant2.Tag = "ENCHANTED_BONE";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            //string
            btnItemVariant1.BackgroundImage = Properties.Resources._string;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_string;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "STRING";
            btnItemVariant2.Tag = "ENCHANTED_STRING";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            //spider eye
            btnItemVariant1.BackgroundImage = Properties.Resources.spider_eye;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_spider_eye;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_fermented_spider_eye;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SPIDER_EYE";
            btnItemVariant2.Tag = "ENCHANTED_SPIDER_EYE";
            btnItemVariant3.Tag = "ENCHANTED_FERMENTED_SPIDER_EYE";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            //gun powder
            btnItemVariant1.BackgroundImage = Properties.Resources.gunpowder;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_gunpowder;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_firework_rocket;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SULPHUR";
            btnItemVariant2.Tag = "ENCHANTED_GUNPOWDER";
            btnItemVariant3.Tag = "ENCHANTED_FIREWORK_ROCKET";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            //ender pearl
            btnItemVariant1.BackgroundImage = Properties.Resources.ender_pearl;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_ender_pearl;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_eye_of_ender;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "ENDER_PEARL";
            btnItemVariant2.Tag = "ENCHANTED_ENDER_PEARL";
            btnItemVariant3.Tag = "ENCHANTED_EYE_OF_ENDER";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            //ghast tear
            btnItemVariant1.BackgroundImage = Properties.Resources.ghast_tear;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_ghast_tear;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "GHAST_TEAR";
            btnItemVariant2.Tag = "ENCHANTED_GHAST_TEAR";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            //slime ball
            btnItemVariant1.BackgroundImage = Properties.Resources.slimeball;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_slimeball;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_slime_block;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SLIME_BALL";
            btnItemVariant2.Tag = "ENCHANTED_SLIME_BALL";
            btnItemVariant3.Tag = "ENCHANTED_SLIME_BLOCK";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            //blaze rod
            btnItemVariant1.BackgroundImage = Properties.Resources.blaze_rod;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_blaze_powder;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_blaze_rod;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "BLAZE_ROD";
            btnItemVariant2.Tag = "ENCHANTED_BLAZE_POWDER";
            btnItemVariant3.Tag = "ENCHANTED_BLAZE_ROD";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnItemVariant1.BackgroundImage = Properties.Resources.magma_cream;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_magam_cream;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "MAGMA_CREAM";
            btnItemVariant2.Tag = "ENCHANTED_MAGMA_CREAM";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
        }
        #endregion Combat
        #region Woods and Fishing
        private void btnWoodFishing_Click(object sender, EventArgs e)
        {
            showSubMenu(panelWoodFishSidemenu);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            //oak
            btnItemVariant1.BackgroundImage = Properties.Resources.oak_wood;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_oak_wood;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "LOG";
            btnItemVariant2.Tag = "ENCHANTED_OAK_LOG";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            //spruce
            btnItemVariant1.BackgroundImage = Properties.Resources.spruce_wood;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_spruce_wood;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "LOG:1";
            btnItemVariant2.Tag = "ENCHANTED_SPRUCE_LOG";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            //birch
            btnItemVariant1.BackgroundImage = Properties.Resources.birch_wood;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_birch_wood;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "LOG:2";
            btnItemVariant2.Tag = "ENCHANTED_BIRCH_LOG";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            //dark oak
            btnItemVariant1.BackgroundImage = Properties.Resources.dark_oak_wood;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_dark_oak_wood;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "LOG_2:1";
            btnItemVariant2.Tag = "ENCHANTED_DARK_OAK_LOG";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            //acacia
            btnItemVariant1.BackgroundImage = Properties.Resources.acacia_wood;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_acacia_wood;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "LOG_2";
            btnItemVariant2.Tag = "ENCHANTED_ACACIA_LOG";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            //jungle
            btnItemVariant1.BackgroundImage = Properties.Resources.jungle_wood;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_jungle_wood;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "LOG:3";
            btnItemVariant2.Tag = "ENCHANTED_JUNGLE_LOG";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            //raw fish
            btnItemVariant1.BackgroundImage = Properties.Resources.raw_fish;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_raw_fish;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_cooked_fish;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "RAW_FISH";
            btnItemVariant2.Tag = "ENCHANTED_RAW_FISH";
            btnItemVariant3.Tag = "ENCHANTED_COOKED_FISH";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            //salmon
            btnItemVariant1.BackgroundImage = Properties.Resources.salmon;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_raw_salmon;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_cooked_salmon;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "RAW_FISH:1";
            btnItemVariant2.Tag = "ENCHANTED_RAW_SALMON";
            btnItemVariant3.Tag = "ENCHANTED_COOKED_SALMON";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            //clownfish
            btnItemVariant1.BackgroundImage = Properties.Resources.clownfish;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_clownfish;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "RAW_FISH:2";
            btnItemVariant2.Tag = "ENCHANTED_CLOWNFISH";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            //pufferfish
            btnItemVariant1.BackgroundImage = Properties.Resources.pufferfish;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_pufferfish;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "RAW_FISH:3";
            btnItemVariant2.Tag = "ENCHANTED_PUFFERFISH";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //prismarine shard
            btnItemVariant1.BackgroundImage = Properties.Resources.prismarine_shard;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_prismarine_shard;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "PRISMARINE_SHARD";
            btnItemVariant2.Tag = "ENCHANTED_PRISMARINE_SHARD";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            //prismarine crystals
            btnItemVariant1.BackgroundImage = Properties.Resources.prismarine_crystals;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_prismarine_crystals;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "PRISMARINE_CRYSTALS";
            btnItemVariant2.Tag = "ENCHANTED_PRISMARINE_CRYSTALS";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //clay
            btnItemVariant1.BackgroundImage = Properties.Resources.clay;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_clay;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "CLAY_BALL";
            btnItemVariant2.Tag = "ENCHANTED_CLAY_BALL";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            //lily pad
            btnItemVariant1.BackgroundImage = Properties.Resources.lily_pad;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_lily_pad;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "WATER_LILY";
            btnItemVariant2.Tag = "ENCHANTED_WATER_LILY";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            //ink
            btnItemVariant1.BackgroundImage = Properties.Resources.ink_sack;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_ink_sack;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "INK_SACK";
            btnItemVariant2.Tag = "ENCHANTED_INK_SACK";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            //sponge
            btnItemVariant1.BackgroundImage = Properties.Resources.sponge;
            btnItemVariant2.BackgroundImage = Properties.Resources.enchanted_sponge;
            btnItemVariant3.BackgroundImage = Properties.Resources.enchanted_wet_sponge;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SPONGE";
            btnItemVariant2.Tag = "ENCHANTED_SPONGE";
            btnItemVariant3.Tag = "ENCHANTED_WET_SPONGE";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }
        #endregion Woods and Fishing
        #region Oddities
        private void btnOddities_Click(object sender, EventArgs e)
        {
            showSubMenu(panelOdditiesSidemenu);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            //revenant flesh
            btnItemVariant1.BackgroundImage = Properties.Resources.revenant_flesh;
            btnItemVariant2.BackgroundImage = Properties.Resources.revenant_viscera;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "REVENANT_FLESH";
            btnItemVariant2.Tag = "REVENANT_VISCERA";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            //tarantula web
            btnItemVariant1.BackgroundImage = Properties.Resources.tarantula_web;
            btnItemVariant2.BackgroundImage = Properties.Resources.tarantula_silk;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "TARANTULA_WEB";
            btnItemVariant2.Tag = "TARANTULA_SILK";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            //wolf tooth
            btnItemVariant1.BackgroundImage = Properties.Resources.wolf_tooth;
            btnItemVariant2.BackgroundImage = Properties.Resources.golden_tooth;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "WOLF_TOOTH";
            btnItemVariant2.Tag = "GOLDEN_TOOTH";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            //hot potato book
            btnItemVariant1.BackgroundImage = Properties.Resources.hot_potato_book;
            btnItemVariant2.BackgroundImage = Properties.Resources._null;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "HOT_POTATO_BOOK";
            btnItemVariant2.Tag = "";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            //compactor
            btnItemVariant1.BackgroundImage = Properties.Resources.compactor;
            btnItemVariant2.BackgroundImage = Properties.Resources.super_compactor_3000;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "COMPACTOR";
            btnItemVariant2.Tag = "SUPER_COMPACTOR_3000";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            //summoning eye
            btnItemVariant1.BackgroundImage = Properties.Resources.summoning_eye;
            btnItemVariant2.BackgroundImage = Properties.Resources._null;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "SUMMONING_EYE";
            btnItemVariant2.Tag = "";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            //dragon fragments
            btnItemVariant1.BackgroundImage = Properties.Resources.protector_dragon_fragment;
            btnItemVariant2.BackgroundImage = Properties.Resources.old_dragon_fragment;
            btnItemVariant3.BackgroundImage = Properties.Resources.unstable_dragon_fragment;
            btnItemVariant4.BackgroundImage = Properties.Resources.strong_dragon_fragment;
            btnItemVariant5.BackgroundImage = Properties.Resources.young_dragon_fragment;
            btnItemVariant6.BackgroundImage = Properties.Resources.wise_dragon_fragment;
            btnItemVariant7.BackgroundImage = Properties.Resources.superior_dragon_fragment;
            btnItemVariant1.Tag = "PROTECTOR_FRAGMENT";
            btnItemVariant2.Tag = "OLD_FRAGMENT";
            btnItemVariant3.Tag = "UNSTABLE_FRAGMENT";
            btnItemVariant4.Tag = "STRONG_FRAGMENT";
            btnItemVariant5.Tag = "YOUNG_FRAGMENT";
            btnItemVariant6.Tag = "WISE_FRAGMENT";
            btnItemVariant7.Tag = "SUPERIOR_FRAGMENT";
            hideSubmenu();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            //enchanted redstone lamp
            btnItemVariant1.BackgroundImage = Properties.Resources.enchanted_redstone_lamp;
            btnItemVariant2.BackgroundImage = Properties.Resources._null;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "ENCHANTED_REDSTONE_LAMP";
            btnItemVariant2.Tag = "";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            //fuels
            btnItemVariant1.BackgroundImage = Properties.Resources.enchanted_lava_bucket;
            btnItemVariant2.BackgroundImage = Properties.Resources.hamster_wheel;
            btnItemVariant3.BackgroundImage = Properties.Resources.foul_flesh;
            btnItemVariant4.BackgroundImage = Properties.Resources.catalyst;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "ENCHANTED_LAVA_BUCKET";
            btnItemVariant2.Tag = "HAMSTER_WHEEL";
            btnItemVariant3.Tag = "FOUL_FLESH";
            btnItemVariant4.Tag = "CATALYST";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            //candies
            btnItemVariant1.BackgroundImage = Properties.Resources.green_candy;
            btnItemVariant2.BackgroundImage = Properties.Resources.purple_candy;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "GREEN_CANDY";
            btnItemVariant2.Tag = "PURPLE_CANDY";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            //gifts
            btnItemVariant1.BackgroundImage = Properties.Resources.white_gift;
            btnItemVariant2.BackgroundImage = Properties.Resources.green_gift;
            btnItemVariant3.BackgroundImage = Properties.Resources.red_gift;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "WHITE_GIFT";
            btnItemVariant2.Tag = "GREEN_GIFT";
            btnItemVariant3.Tag = "RED_GIFT";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            //stock of stonks
            btnItemVariant1.BackgroundImage = Properties.Resources.stock_of_stonks;
            btnItemVariant2.BackgroundImage = Properties.Resources._null;
            btnItemVariant3.BackgroundImage = Properties.Resources._null;
            btnItemVariant4.BackgroundImage = Properties.Resources._null;
            btnItemVariant5.BackgroundImage = Properties.Resources._null;
            btnItemVariant6.BackgroundImage = Properties.Resources._null;
            btnItemVariant7.BackgroundImage = Properties.Resources._null;
            btnItemVariant1.Tag = "STOCK_OF_STONKS";
            btnItemVariant2.Tag = "";
            btnItemVariant3.Tag = "";
            btnItemVariant4.Tag = "";
            btnItemVariant5.Tag = "";
            btnItemVariant6.Tag = "";
            btnItemVariant7.Tag = "";
            hideSubmenu();
        }
        #endregion Oddities

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.textBox1.Enabled = false;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebBrowser browser = new WebBrowser();
            browser.Show();
            linkLabel1.LinkVisited = true;
        }

        private void btnItemVariant1_Click(object sender, EventArgs e)
        {
            //possible items:
            //wheat, carrot, potato, pumpkin, melon, seeds, red mushroom, brown mushroom, cocoa bean, cactus, sugarcane, feather, leather, pork, raw chicken, mutton, raw rabbit, nether wart, cobble, coal, iron, gold, diamond, lapis, emerald, redstone, quartz, obsidian, glowstone dust, gravel, flint, ice, netherrack, sand, end stone, snowball, rotten flesh, bone, string, spider eye, gunpowder, ender pearl, ghast tear, slimeball, blaze rod, magma cream, oak wood, birch wood, spruce wood, acacia wood, dark oak wood, jungle wood, raw fish, raw salmon, clownfish, pufferfish, prismarine crystal, prismarine shard, clay, lilypad, ink sack, sponge, revenant flesh, tarantula web, wolf tooth, hot potato book, compactor, summoning eye, protector dragon frag, enchanted redstone lamp, enchanted lava bucket, green candy, white gift, stock of stonks
            string title;
            switch (btnItemVariant1.Tag)
            {
                case "CARROT_ITEM":
                    title = "Carrot";
                    break;
                case "POTATO_ITEM":
                    title = "Potato";
                    break;
                case "RED_MUSHROOM":
                    title = "Red Mushroom";
                    break;
                case "BROWN_MUSHROOM":
                    title = "Brown Mushroom";
                    break;
                case "INK_SACK:3":
                    title = "Cocoa Bean";
                    break;
                case "SUGAR_CANE":
                    title = "Sugarcane";
                    break;
                case "RAW_CHICKEN":
                    title = "Raw Chicken";
                    break;
                case "NETHER_STALK":
                    title = "Netherwart";
                    break;
                case "IRON_INGOT":
                    title = "Iron Ingot";
                    break;
                case "GOLD_INGOT":
                    title = "Gold Ingot";
                    break;
                case "INK_SACK:4":
                    title = "Lapis Lazuli";
                    break;
                case "GLOWSTONE_DUST":
                    title = "Glowstone Dust";
                    break;
                case "ENDER_STONE":
                    title = "End Stone";
                    break;
                case "SNOW_BALL":
                    title = "Snowball";
                    break;
                case "ROTTEN_FLESH":
                    title = "Rotten Flesh";
                    break;
                case "SPIDER_EYE":
                    title = "Spider Eye";
                    break;
                case "ENDER_PEARL":
                    title = "Ender Pearl";
                    break;
                case "GHAST_TEAR":
                    title = "Ghast Tear";
                    break;
                case "SLIME_BALL":
                    title = "Slime Ball";
                    break;
                case "BLAZE_ROD":
                    title = "Blaze Rod";
                    break;
                case "MAGMA_CREAM":
                    title = "Magma Cream";
                    break;
                case "LOG":
                    title = "Oak Wood";
                    break;
                case "LOG:2":
                    title = "Birch Wood";
                    break;
                case "LOG:1":
                    title = "Spruce Wood";
                    break;
                case "LOG_2":
                    title = "Acacia Wood";
                    break;
                case "LOG_2:1":
                    title = "Dark Oak Wood";
                    break;
                case "LOG:3":
                    title = "Jungle Wood";
                    break;
                case "RAW_FISH":
                    title = "Raw Fish";
                    break;
                case "RAW_FISH:1":
                    title = "Raw Salmon";
                    break;
                case "RAW_FISH:2":
                    title = "Clownfish";
                    break;
                case "RAW_FISH:3":
                    title = "Pufferfish";
                    break;
                case "PRISMARINE_CRYSTALS":
                    title = "Prismarine Crystals";
                    break;
                case "PRISMARINE_SHARD":
                    title = "Prismarine Shard";
                    break;
                case "CLAY_BALL":
                    title = "Clay";
                    break;
                case "WATER_LILY":
                    title = "Lily Pad";
                    break;
                case "INK_SACK":
                    title = "Ink Sack";
                    break;
                case "REVENANT_FLESH":
                    title = "Revenant Flesh";
                    break;
                case "TARANTULA_WEB":
                    title = "Tarantula Web";
                    break;
                case "WOLF_TOOTH":
                    title = "Wolf Tooth";
                    break;
                case "HOT_POTATO_BOOK":
                    title = "Hot Potato Book";
                    break;
                case "SUMMONING_EYE":
                    title = "Summoning Eye";
                    break;
                case "PROTECTOR_FRAGMENT":
                    title = "Protector Fragment";
                    break;
                case "ENCHANTED_REDSTONE_LAMP":
                    title = "Enchanted Redstone Lamp";
                    break;
                case "ENCHANTED_LAVA_BUCKET":
                    title = "Enchanted Lava Bucket";
                    break;
                case "GREEN_CANDY":
                    title = "Green Candy";
                    break;
                case "WHITE_GIFT":
                    title = "White Gift";
                    break;
                case "STOCK_OF_STONKS":
                    title = "Stock of Stonks";
                    break;
                default:
                    try
                    {
                        title = btnItemVariant1.Tag.ToString().ToLower();
                        title = char.ToUpper(title[0]) + title.Substring(1);
                    } catch(Exception)
                    {
                        title = "";
                    }

                    break;
            }
            if (btnItemVariant1.Tag.ToString() == "" || title == "")
            {
                return;
            }
            else
            {
                openChildForm(new ChildForm(title, btnItemVariant1.Tag.ToString(), api_key));
            }
        }
        private void btnItemVariant2_Click(object sender, EventArgs e)
        {
            //possible items:
            //enchanted bread, ench carrot, ench potato, ench pumpkin, ench melon, ench seeds, ench red mush, ench brown mush, ench cocoa bean, ench cactus green, ench sugar, ench feather, ench leather, ench pork, ench raw chicken, ench mutton, ench raw rabbit, ench nether stalk, ench cobble, ench coal, ench iron, ench gold, ench diamond, ench lapis lazuli, ench emerald, ench redstone, ench quartz, ench obsidian, ench glowstone dust, ench flint, packed ice, ench sand, ench ender stone, snow block, ench rotten flesh, ench string, ench spider eye, ench gunpowder, ench ender pearl, ench ghast tear, ench slime ball, ench blaze powder, ench magma cream, ench oak wood, ench spruce wood, ench birch wood, ench dark wood, ench acacia wood, ench jungle wood, ench raw fish, ench raw salmon, ench clownfish, ench pufferfish, ench prismarine shard, ench prismarine crystals, ench clay ball, ench water lily, ench sponge, revenant viscera, tarantula silk, golden tooth, super compactor 3000, old fragment, hamster wheel, green gift
            string title;
            switch (btnItemVariant2.Tag)
            {
                case "ENCHANTED_BREAD":
                    title = "Enchanted Bread";
                    break;
                case "ENCHANTED_CARROT":
                    title = "Enchanted Carrot";
                    break;
                case "ENCHANTED_POTATO":
                    title = "Enchanted Potato";
                    break;
                case "ENCHANTED_PUMPKIN":
                    title = "Enchanted Pumpkin";
                    break;
                case "ENCHANTED_MELON":
                    title = "Enchanted Melon";
                    break;
                case "ENCHANTED_SEEDS":
                    title = "Enchanted Seeds";
                    break;
                case "ENCHANTED_RED_MUSHROOM":
                    title = "Enchanted Red Mushroom";
                    break;
                case "ENCHANTED_COCOA":
                    title = "Enchanted Cocoa";
                    break;
                case "ENCHANTED_CACTUS_GREEN":
                    title = "Enchanted Cactus Green";
                    break;
                case "ENCHANTED_SUGAR":
                    title = "Enchanted Sugar";
                    break;
                case "ENCHANTED_FEATHER":
                    title = "Enchanted Feather";
                    break;
                case "ENCHANTED_LEATHER":
                    title = "Enchanted Leather";
                    break;;
                case "ENCHANTED_PORK":
                    title = "Enchanted Pork";
                    break;
                case "ENCHANTED_RAW_CHICKEN":
                    title = "Enchanted Raw Chicken";
                    break;
                case "ENCHANTED_MUTTON":
                    title = "Enchanted Mutton";
                    break;
                case "ENCHANTED_RABBIT":
                    title = "Enchanted Rabbit";
                    break;
                case "ENCHANTED_NETHER_STALK":
                    title = "Enchanted Netherwart";
                    break;
                case "ENCHANTED_FLINT":
                    title = "Enchanted Flint";
                    break;
                case "ENCHANTED_ROTTEN_FLESH":
                    title = "Enchanted Rotten Flesh";
                    break;
                case "ENCHANTED_BONE":
                    title = "Enchanted Bone";
                    break;
                case "ENCHANTED_STRING":
                    title = "Enchanted String";
                    break;
                case "ENCHANTED_SPIDER_EYE":
                    title = "Enchanted Spider Eye";
                    break;
                case "ENCHANTED_GUNPOWDER":
                    title = "Enchanted Gunpowder";
                    break;
                case "ENCHANTED_ENDER_PEARL":
                    title = "Enchanted Ender Pearl";
                    break;
                case "ENCHANTED_GHAST_TEAR":
                    title = "Enchanted Ghast Tear";
                    break;
                case "ENCHANTED_SLIME_BALL":
                    title = "Enchanted Slime Ball";
                    break;
                case "ENCHANTED_BLAZE_POWDER":
                    title = "Enchanted Blaze Powder";
                    break;
                case "ENCHANTED_MAGMA_CREAM":
                    title = "Enchanted Magma Cream";
                    break;
                case "ENCHANTED_COBBLESTONE":
                    title = "Enchanted Cobblestone";
                    break;
                case "ENCHANTED_COAL":
                    title = "Enchanted Coal";
                    break;
                case "ENCHANTED_IRON":
                    title = "Enchanted Iron";
                    break;
                case "ENCHANTED_GOLD":
                    title = "Enchanted Gold";
                    break;
                case "ENCHANTED_DIAMOND":
                    title = "Enchanted Diamond";
                    break;
                case "ENCHANTED_LAPIS_LAZULI":
                    title = "Enchanted Lapis Lazuli";
                    break;
                case "ENCHANTED_EMERALD":
                    title = "Enchanted Emerald";
                    break;
                case "ENCHANTED_REDSTONE":
                    title = "Enchanted Redstone";
                    break;
                case "ENCHANTED_QUARTZ":
                    title = "Enchanted Quartz";
                    break;
                case "ENCHANTED_OBSIDIAN":
                    title = "Enchanted Obsidian";
                    break;
                case "ENCHANTED_GLOWSTONE_DUST":
                    title = "Enchanted Glowstone Dust";
                    break;
                case "ENCHANTED_ICE":
                    title = "Enchanted Ice";
                    break;
                case "ENCHANTED_SAND":
                    title = "Enchanted Sand";
                    break;
                case "ENCHANTED_ENDSTONE":
                    title = "Enchanted Endstone";
                    break;
                case "SNOW_BLOCK":
                    title = "Snow Block";
                    break;
                case "ENCHANTED_OAK_LOG":
                    title = "Enchanted Oak Wood";
                    break;
                case "ENCHANTED_BIRCH_LOG":
                    title = "Enchanted Birch Wood";
                    break;
                case "ENCHANTED_SPRUCE_LOG":
                    title = "Enchanted Spruce Wood";
                    break;
                case "ENCHANTED_DARK_OAK_LOG":
                    title = "Enchanted Dark Oak Wood";
                    break;
                case "ENCHANTED_ACACIA_LOG":
                    title = "Enchanted Acacia Wood";
                    break;
                case "ENCHANTED_JUNGLE_LOG":
                    title = "Enchanted Jungle Wood";
                    break;
                case "ENCHANTED_RAW_FISH":
                    title = "Enchanted Raw Fish";
                    break;
                case "ENCHANTED_RAW_SALMON":
                    title = "Enchanted Raw Salmon";
                    break;
                case "ENCHANTED_CLOWNFISH":
                    title = "Enchanted Clownfish";
                    break;
                case "ENCHANTED_PUFFERFISH":
                    title = "Enchanted Pufferfish";
                    break;
                case "ENCHANTED_PRISMARINE_SHARD":
                    title = "Enchanted Prismarine Shard";
                    break;
                case "ENCHANTED_PRISMARINE_CRYSTALS":
                    title = "Enchanted Prismarine Crystals";
                    break;
                case "ENCHANTED_CLAY_BALL":
                    title = "Enchanted Clay Ball";
                    break;
                case "ENCHANTED_WATER_LILY":
                    title = "Enchanted Water Lily";
                    break;
                case "ENCHANTED_INK_SACK":
                    title = "Enchanted Ink Sack";
                    break;
                case "ENCHANTED_SPONGE":
                    title = "Enchanted Sponge";
                    break;
                case "REVENANT_VISCERA":
                    title = "Revenant Viscera";
                    break;
                case "TARANTULA_SILK":
                    title = "Tarantula Silk";
                    break;
                case "GOLDEN_TOOTH":
                    title = "Golden Tooth";
                    break;
                case "SUPER_COMPACTOR_3000":
                    title = "Super Compactor 3000";
                    break;
                case "HAMSTER_WHEEL":
                    title = "Hamster Wheel";
                    break;
                case "PURPLE_CANDY":
                    title = "Purple Candy";
                    break;
                case "GREEN_GIFT":
                    title = "Green Gift";
                    break;
                case "OLD_FRAGMENT":
                    title = "Old Fragment";
                    break;


                default:
                    try
                    {title = btnItemVariant2.Tag.ToString().ToLower();
                     title = char.ToUpper(title[0]) + title.Substring(1);}
                    catch (Exception)
                    {title = "";}
                    break;
            }
            if (btnItemVariant2.Tag.ToString() == "" || title == "")
            {
                return;
            }
            else
            {
                openChildForm(new ChildForm(title, btnItemVariant2.Tag.ToString(), api_key));
            }
        }
        private void btnItemVariant3_Click(object sender, EventArgs e)
        {
            //possible items:
            //haybale, enchanted carrot on a stick, enchanted baked potato, enchanted glistering melon, red mushroom block, brown mushroom block, enchanted cookie, enchanted cactus, raw beef, enchanted grilled pork, enchanted egg, enchanted cooked mutton, rabbit's foot, enchanted charcoal, enchanted iron block, enchanted gold block, enchanted diamond block, endchanted lapis lazuli block, enchanted emerald block, enchanted redstone block, enchanted quartz block, enchanted glowstone, enchanted ice, enchanted snow block, enchanted fermented spider eye, enchanted firework rocket, enchanted eye of ender, enchanted slime block, enchanted blaze rod, enchanted cooked fish, enchanted cooked salmon, enchanted wet sponge, unstable fragment, foul flesh, red gift
            string title;
            switch(btnItemVariant3.Tag)
            {
                case "HAY_BLOCK":
                    title = "Haybale";
                    break;
                case "ENCHANTED_CARROT_ON_A_STICK":
                    title = "Enchanted Carrot on a Stick";
                    break;
                case "ENCHANTED_HOT_POTATO":
                    title = "Enchanted Baked Potato";
                    break;
                case "ENCHANTED_GLISTERING_MELON":
                    title = "Enchanted Glistering Melon";
                    break;
                case "HUGE_MUSHROOM_1":
                    title = "Red Mushroom Block";
                    break;
                case "HUGE_MUSHROOM_2":
                    title = "Brown Mushroom Block";
                    break;
                case "ENCHANTED_COOKIE":
                    title = "Enchanted Cookie";
                    break;
                case "ENCHANTED_CACTUS":
                    title = "Enchanted Cactus";
                    break;
                case "ENCHANTED_PAPER":
                    title = "Enchanted Paper";
                    break;
                case "RAW_BEEF":
                    title = "Raw Beef";
                    break;
                case "ENCHANTED_GRILLED_PORK":
                    title = "Enchanted Grilled Pork";
                    break;
                case "ENCHANTED_EGG":
                    title = "Enchanted Egg";
                    break;
                case "ENCHANTED_COOKED_MUTTON":
                    title = "Enchanted Cooked Mutton";
                    break;
                case "RABBIT_FOOT":
                    title = "Rabbit's Foot";
                    break;
                case "ENCHANTED_CHARCOAL":
                    title = "Enchanted Charcoal";
                    break;
                case "ENCHANTED_IRON_BLOCK":
                    title = "Enchanted Iron Block";
                    break;
                case "ENCHANTED_GOLD_BLOCK":
                    title = "Enchanted Gold Block";
                    break;
                case "ENCHANTED_DIAMOND_BLOCK":
                    title = "Enchanted Diamond Block";
                    break;
                case "ENCHANTED_LAPIS_LAZULI_BLOCK":
                    title = "Enchanted Lapis Lazuli Block";
                    break;
                case "ENCHANTED_EMERALD_BLOCK":
                    title = "Enchanted Emerald Block";
                    break;
                case "ENCHANTED_REDSTONE_BLOCK":
                    title = "Enchanted Redstone Block";
                    break;
                case "ENCHANTED_QUARTZ_BLOCK":
                    title = "Enchanted Quartz Block";
                    break;
                case "ENCHANTED_GLOWSTONE":
                    title = "Enchanted Glowstone Block";
                    break;
                case "ENCHANTED_ICE":
                    title = "Enchanted Ice";
                    break;
                case "ENCHANTED_SNOW_BLOCK":
                    title = "Enchanted Snow Block";
                    break;
                case "ENCHANTED_FERMENTED_SPIDER_EYE":
                    title = "Enchanted Fermented Spider Eye";
                    break;
                case "ENCHANTED_EYE_OF_ENDER":
                    title = "Enchanted Eye of Ender";
                    break;
                case "ENCHANTED_FIREWORK_ROCKET":
                    title = "Enchanted Firework Rocket";
                    break;
                case "ENCHANTED_SLIME_BLOCK":
                    title = "Enchanted Slime Block";
                    break;
                case "ENCHANTED_BLAZE_ROD":
                    title = "Enchanted Blaze Rod";
                    break;
                case "RED_GIFT":
                    title = "Red Gift";
                    break;
                case "UNSTABLE_FRAGMENT":
                    title = "Unstable Fragment";
                    break;
                case "ENCHANTED_COOKED_FISH":
                    title = "Enchanted Cooked Fish";
                    break;
                case "ENCHANTED_COOKED_SALMON":
                    title = "Enchanted Cooked Salmon";
                    break;
                case "FOUL_FLESH":
                    title = "Foul Flesh";
                    break;
                default:
                    try
                    {title = btnItemVariant1.Tag.ToString().ToLower();
                     title = char.ToUpper(title[0]) + title.Substring(1);}
                    catch (Exception)
                    { title = "";}
                    break;
            }
            if (btnItemVariant3.Tag.ToString() == "" || title == "")
            {
                return;
            }
            else
            {
                openChildForm(new ChildForm(title, btnItemVariant3.Tag.ToString(), api_key));
            }

        }
        private void btnItemVariant4_Click(object sender, EventArgs e)
        {
            //possible items:
            //enchanted haybale, enchanted golden carrot, enchanted melon block, enchanted red mushroom block, enchanted brown mushroom block, enchanted sugarcane, enchanted raw beef, enchanted cake, rabbit hide, enchanted block of coal, enchanted packed ice, strong fragment, catalyst
            string title;
            switch(btnItemVariant4.Tag)
            {
                case "ENCHANTED_HAY_BLOCK":
                    title = "Enchanted Haybale";
                    break;
                case "ENCHANTED_GOLDEN CARROT":
                    title = "Enchanted Golden Carrot";
                    break;
                case "ENCHANTED_MELON_BLOCK":
                    title = "Enchanted Melon Block";
                    break;
                case "ENCHANTED_HUGE_MUSHROOM_1":
                    title = "Enchanted Red Mushroom Block";
                    break;
                case "ENCHANTED_HUGE_MUSHROOM_2":
                    title = "Enchanted Brown Mushroom Block";
                    break;
                case "ENCHANTED_SUGARCANE":
                    title = "Enchanted Sugarcane";
                    break;
                case "ENCHANTED_CAKE":
                    title = "Enchanted Cake";
                    break;
                case "RABBIT_HIDE":
                    title = "Rabbit Hide";
                    break;
                case "ENCHANTED_COAL_BLOCK":
                    title = "Enchanted Coal Block";
                    break;
                case "ENCHANTED_PACKED_ICE":
                    title = "Enchanted Packed Ice";
                    break;
                case "STRONG_FRAGMENT":
                    title = "Strong Fragment";
                    break;
                case "CATALYST":
                    title = "Catalyst";
                    break;
                default:
                    try
                    {title = btnItemVariant1.Tag.ToString().ToLower();
                     title = char.ToUpper(title[0]) + title.Substring(1);}
                    catch (Exception)
                    { title = ""; }
                    break;
            }
            if (btnItemVariant4.Tag.ToString() == "" || title == "")
                return;
            else
                openChildForm(new ChildForm(title, btnItemVariant4.Tag.ToString(), api_key));
        }
        private void btnItemVariant5_Click(object sender, EventArgs e)
        {
            //possible items:
            //super enchanted egg, enchanted rabbits foot, young fragment
            string title;
            switch(btnItemVariant5.Tag)
            {
                case "SUPER_ENCHANTED_EGG":
                    title = "Super Enchanted Egg";
                    break;
                case "ENCHANTED_RABBIT_FOOT":
                    title = "Enchanted Rabbit Foot";
                    break;
                case "YOUNG_FRAGMENT":
                    title = "Young Fragment";
                    break;
                default:
                    try
                    {title = btnItemVariant1.Tag.ToString().ToLower();
                     title = char.ToUpper(title[0]) + title.Substring(1);}
                    catch (Exception)
                    { title = ""; }
                    break;
            }
            if (btnItemVariant5.Tag.ToString() == "" || title == "")
                return;
            else
                openChildForm(new ChildForm(title, btnItemVariant5.Tag.ToString(), api_key));
        }
        private void btnItemVariant6_Click(object sender, EventArgs e)
        {
            //possible items:
            //enchanted rabbit hide, wise fragment
            string title;
            if (btnItemVariant6.Tag.ToString() == "ENCHANTED_RABBIT_HIDE")
            {

                title = "Enchanted Rabbit Hide";
            }
            else
            {
                title = "Wise Fragment";
            }

            if (btnItemVariant6.Tag.ToString() == "" || title == "")
                return;
            else
                openChildForm(new ChildForm(title, btnItemVariant6.Tag.ToString(), api_key));
        }
        private void btnItemVariant7_Click(object sender, EventArgs e)
        {
            string title;
            title = "Superior Dragon Fragment";
            if (btnItemVariant7.Tag.ToString() == "" || title == "")
                return;
            else
                openChildForm(new ChildForm(title, btnItemVariant7.Tag.ToString(), api_key));
        }
    }
}

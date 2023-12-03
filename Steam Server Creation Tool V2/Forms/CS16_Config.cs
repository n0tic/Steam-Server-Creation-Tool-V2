using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Steam_Server_Creation_Tool_V2.Forms
{
    public partial class CS16_Config : Form
    {
        private InstalledServer app = null;

        public CS16_Config(InstalledServer app)
        {
            this.app = app;
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, EventArgs e) => Close();
        private void MovePanel_MouseDown(object sender, MouseEventArgs e) => Core.MoveWindow(this, e);

        private void CS16_Config_Load(object sender, EventArgs e)
        {
            ConfigBase_combobox.SelectedIndex = 0;
            sv_rcon_banpenalty_combobox.SelectedIndex = 0;
            sv_rcon_minfaliuretime.SelectedIndex = 5;
            sv_lan.SelectedIndex = 0;
            sv_region.SelectedIndex = 0;

            log.SelectedIndex = 0;
            sv_logbans.SelectedIndex = 0;
            sv_logecho.SelectedIndex = 0;
            sv_logfile.SelectedIndex = 0;
            sv_log_onefile.SelectedIndex = 0;

            tv_enabled.SelectedIndex = 0;
            auto_record.SelectedIndex = 0;

            bot_add.SelectedIndex = 0;
            bot_quota.Value = 4;
            bot_difficulty.SelectedIndex = 0;
            bot_chatter.SelectedIndex = 3;
            bot_auto_follow.SelectedIndex = 0;
            bot_auto_vacate.SelectedIndex = 0;
            bot_join_after_player.SelectedIndex = 0;
            bot_defer_to_human.SelectedIndex = 0;
            bot_allow_rogues.SelectedIndex = 0;
            bot_walk.SelectedIndex = 0;
            bot_join_team.SelectedIndex = 0;
            bot_allow_grenades.SelectedIndex = 0;
            bot_allow_pistols.SelectedIndex = 0;
            bot_allow_sub_machine_guns.SelectedIndex = 0;
            bot_allow_shotguns.SelectedIndex = 0;
            bot_allow_rifles.SelectedIndex = 0;
            bot_allow_snipers.SelectedIndex = 0;
            bot_allow_machine_guns.SelectedIndex = 0;

            sv_timeout.SelectedIndex = 10;
            mp_friendlyfire.SelectedIndex = 1;
            mp_footsteps.SelectedIndex = 0;
            mp_autoteambalance.SelectedIndex = 0;
            mp_autokick.SelectedIndex = 1;
            mp_flashlight.SelectedIndex = 1;
            mp_tkpunish.SelectedIndex = 0;
            mp_forcecamera.SelectedIndex = 1;
            sv_alltalk.SelectedIndex = 1;
            sv_pausable.SelectedIndex = 1;
            sv_consistency.SelectedIndex = 0;
            sv_cheats.SelectedIndex = 1;
            sv_allowupload.SelectedIndex = 0;
            sv_allowdownload.SelectedIndex = 0;
            sv_voiceenable.SelectedIndex = 0;
            mp_allowspectators.SelectedIndex = 0;

        }

        private void ConfigBase_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
                Generic CFG (Default)
                Optimized CFG
                High Performance CFG
            */

            if (ConfigBase_combobox.SelectedIndex == 0)
            {
                sv_minrate.Value = 0;
                sv_maxrate.Value = 0;
                decalfrequency.Value = 10;
                sv_maxupdaterate.Value = 60;
                sv_minupdaterate.Value = 10;
            }
            else if (ConfigBase_combobox.SelectedIndex == 1)
            {
                sv_minrate.Value = 4000;
                sv_maxrate.Value = 8000;
                decalfrequency.Value = 60;
                sv_maxupdaterate.Value = 60;
                sv_minupdaterate.Value = 10;
            }
            else
            {
                sv_minrate.Value = 0;
                sv_maxrate.Value = 0;
                decalfrequency.Value = 10;
                sv_maxupdaterate.Value = 100;
                sv_minupdaterate.Value = 20;
            }
        }

        public string GetNoYes(ComboBox inputText)
        {
            if (inputText.Text == "No")
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        private string GetRegionValue(ComboBox region)
        {
            switch (region.Text)
            {
                case "World (default)":
                    return "255";
                case "US - East":
                    return "0";
                case "US - West":
                    return "1";
                case "South America":
                    return "2";
                case "Europe":
                    return "3";
                case "Asia":
                    return "4";
                case "Australia":
                    return "5";
                case "Middle East":
                    return "6";
                case "Africa":
                    return "7";
                default:
                    return "";
            }
        }

        private string GetTimeoutValue(ComboBox inputText)
        {
            switch (inputText.Text)
            {
                case "15 Seconds":
                case "20 Seconds":
                case "25 Seconds":
                case "30 Seconds":
                case "35 Seconds":
                case "40 Seconds":
                case "45 Seconds":
                case "50 Seconds":
                case "55 Seconds":
                case "60 Seconds":
                case "65 Seconds":
                    return inputText.Text.Split(' ')[0];
                case "2 Minutes":
                    return "120";
                default:
                    return "";
            }
        }

        private string GetBotQuotaModeValue(ComboBox botQuotaMode)
        {
            return botQuotaMode.Text == "Fill" ? "fill" : "normal";
        }

        private string GetBotChatterValue(ComboBox botChatter)
        {
            switch (botChatter.Text)
            {
                case "Off":
                    return "off";
                case "Radio":
                    return "radio";
                case "Minimal":
                    return "minimal";
                case "Normal":
                    return "normal";
                default:
                    return "";
            }
        }

        private string GetBotJoinTeamValue(ComboBox botJoinTeam)
        {
            switch (botJoinTeam.Text)
            {
                case "Any":
                    return "any";
                case "Terrorist":
                    return "t";
                case "Counter - Terrorist":
                    return "ct";
                default:
                    return "";
            }
        }

        private string GetBotDifficultyValue(ComboBox botDifficulty)
        {
            switch (botDifficulty.Text)
            {
                case "Easy":
                    return "0";
                case "Normal":
                    return "1";
                case "Hard":
                    return "2";
                case "Expert":
                    return "3";
                default:
                    return "1";
            }
        }

        private void SaveSettings_Button_Click(object sender, EventArgs e)
        {
            string sv_lan_text = (sv_lan.Text == "LAN & Internet") ? "0" : "1";

            string cfg_script = Properties.Resources.server_cfg;
            cfg_script = cfg_script
                .Replace("{hostname}", $"{hostname.Text}")
                .Replace("{sv_lan}", $"{sv_lan_text}")
                .Replace("{sv_region}", $"{GetRegionValue(sv_region)}")

                .Replace("{sv_password}", $"{sv_password.Text}")
                .Replace("{rcon_password}", $"{rcon_password.Text}")

                .Replace("{log}", $"{GetNoYes(log)}")
                .Replace("{sv_logbans}", $"{GetNoYes(sv_logbans)}")
                .Replace("{sv_logecho}", $"{GetNoYes(sv_logecho)}")
                .Replace("{sv_logfile}", $"{GetNoYes(sv_logfile)}")
                .Replace("{sv_log_onefile}", $"{GetNoYes(sv_log_onefile)}")

                .Replace("{sv_rcon_banpenalty}", $"{sv_rcon_banpenalty_combobox.Text}")
                .Replace("{sv_rcon_maxfailures}", $"{sv_rcon_maxfaliures.Value}")
                .Replace("{sv_rcon_minfailures}", $"{sv_rcon_minfaliures.Value}")
                .Replace("{sv_rcon_minfailuretime}", $"{sv_rcon_minfaliuretime.Text}")

                .Replace("{sv_minrate}", $"{sv_minrate.Value}")
                .Replace("{sv_maxrate}", $"{sv_maxrate.Value}")
                .Replace("{decalfrequency}", $"{decalfrequency.Value}")
                .Replace("{sv_maxupdaterate}", $"{sv_maxupdaterate.Value}")
                .Replace("{sv_minupdaterate}", $"{sv_minupdaterate.Value}")

                .Replace("{mp_friendlyfire}", $"{GetNoYes(mp_friendlyfire)}")
                .Replace("{mp_footsteps}", $"{GetNoYes(mp_footsteps)}")
                .Replace("{mp_autoteambalance}", $"{GetNoYes(mp_autoteambalance)}")
                .Replace("{mp_autokick}", $"{GetNoYes(mp_autokick)}")
                .Replace("{mp_flashlight}", $"{GetNoYes(mp_flashlight)}")
                .Replace("{mp_tkpunish}", $"{GetNoYes(mp_tkpunish)}")
                .Replace("{mp_forcecamera}", $"{GetNoYes(mp_forcecamera)}")
                .Replace("{sv_alltalk}", $"{GetNoYes(sv_alltalk)}")
                .Replace("{sv_pausable}", $"{GetNoYes(sv_pausable)}")
                .Replace("{sv_consistency}", $"{GetNoYes(sv_consistency)}")
                .Replace("{sv_cheats}", $"{GetNoYes(sv_cheats)}")
                .Replace("{sv_allowupload}", $"{GetNoYes(sv_allowupload)}")
                .Replace("{sv_allowdownload}", $"{GetNoYes(sv_allowdownload)}")
                .Replace("{sv_maxspeed}", $"{sv_maxspeed.Value}")
                .Replace("{mp_limitteams}", $"{mp_limitteams.Value}")
                .Replace("{mp_hostagepenalty}", $"{mp_hostagepenalty.Value}")
                .Replace("{sv_voiceenable}", $"{GetNoYes(sv_voiceenable)}")
                .Replace("{mp_allowspectators}", $"{GetNoYes(mp_allowspectators)}")
                .Replace("{mp_timelimit}", $"{mp_timelimit.Value}")
                .Replace("{mp_chattime}", $"{mp_chattime.Value}")
                .Replace("{sv_timeout}", $"{GetTimeoutValue(sv_timeout)}")

                .Replace("{mp_freezetime}", $"{mp_freezetime.Value}")
                .Replace("{mp_roundtime}", $"{mp_roundtime.Value}")
                .Replace("{mp_startmoney}", $"{mp_startmoney.Value}")
                .Replace("{mp_c4timer}", $"{mp_c4timer.Value}")
                .Replace("{mp_fraglimit}", $"{mp_fraglimit.Value}")
                .Replace("{mp_maxrounds}", $"{mp_maxrounds.Value}")
                .Replace("{mp_winlimit}", $"{mp_winlimit.Value}")
                .Replace("{mp_playerid}", $"{GetNoYes(mp_playerid)}")
                .Replace("{mp_spawnprotectiontime}", $"{mp_spawnprotectiontime.Value}")

                .Replace("{bot_add}", $"{GetNoYes(bot_add)}")
                .Replace("{bot_quota}", $"{bot_quota.Value}")
                .Replace("{bot_quota_mode}", $"{GetBotQuotaModeValue(bot_quota_mode)}")
                .Replace("{bot_difficulty}", $"{GetBotDifficultyValue(bot_difficulty)}")
                .Replace("{bot_chatter}", $"{GetBotChatterValue(bot_chatter)}")
                .Replace("{bot_auto_follow}", $"{GetNoYes(bot_auto_follow)}")
                .Replace("{bot_auto_vacate}", $"{GetNoYes(bot_auto_vacate)}")
                .Replace("{bot_join_after_player}", $"{GetNoYes(bot_join_after_player)}")
                .Replace("{bot_defer_to_human}", $"{GetNoYes(bot_defer_to_human)}")
                .Replace("{bot_allow_rogues}", $"{GetNoYes(bot_allow_rogues)}")
                .Replace("{bot_walk}", $"{GetNoYes(bot_walk)}")
                .Replace("{bot_join_team}", $"{GetBotJoinTeamValue(bot_join_team)}")
                .Replace("{bot_eco_limit}", $"{bot_eco_limit.Value}")
                .Replace("{bot_allow_grenades}", $"{GetNoYes(bot_allow_grenades)}")
                .Replace("{bot_allow_pistols}", $"{GetNoYes(bot_allow_pistols)}")
                .Replace("{bot_allow_sub_machine_guns}", $"{GetNoYes(bot_allow_sub_machine_guns)}")
                .Replace("{bot_allow_shotguns}", $"{GetNoYes(bot_allow_shotguns)}")
                .Replace("{bot_allow_rifles}", $"{GetNoYes(bot_allow_rifles)}")
                .Replace("{bot_allow_snipers}", $"{GetNoYes(bot_allow_snipers)}")
                .Replace("{bot_allow_machine_guns}", $"{GetNoYes(bot_allow_machine_guns)}"
                );

            try
            {
                Core.SaveToFile(app.installPath + @"\cstrike\server.cfg", cfg_script);
                MessageBox.Show("The config was saved successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message, "Something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
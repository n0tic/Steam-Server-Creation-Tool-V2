using System;
using System.IO;
using System.Windows.Forms;

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
            bot_quota.SelectedIndex = 4;
            bot_quota_mode.SelectedIndex = 1;
            bot_difficulty.SelectedIndex = 0;
            bot_chatter.SelectedIndex = 3;
            bot_auto_follow.SelectedIndex = 0;
            bot_auto_vacate.SelectedIndex = 0;
            bot_join_after_player.SelectedIndex = 0;
            bot_defer_to_human.SelectedIndex = 0;
            bot_allow_rogues.SelectedIndex = 0;
            bot_walk.SelectedIndex = 0;
            bot_join_team.SelectedIndex = 0;
            BotMode.SelectedIndex = 0;
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

        private void SaveSettings_Button_Click(object sender, EventArgs e)
        {
            string sv_lan_text = "";
            if(sv_lan.Text == "LAN & Internet") sv_lan_text = "0";
            else sv_lan_text = "1";

            string sv_region_text = "";
            if (sv_region.Text == "World (default)") sv_region_text = "255";
            else if (sv_region.Text == "US - East") sv_region_text = "0";
            else if (sv_region.Text == "US - West") sv_region_text = "1";
            else if (sv_region.Text == "South America") sv_region_text = "2";
            else if (sv_region.Text == "Europe") sv_region_text = "3";
            else if (sv_region.Text == "Asia") sv_region_text = "4";
            else if (sv_region.Text == "Australia") sv_region_text = "5";
            else if (sv_region.Text == "Middle East") sv_region_text = "6";
            else if (sv_region.Text == "Africa") sv_region_text = "7";

            string sv_log_text = "";
            if (log.Text == "Off") sv_log_text = "off";
            else sv_log_text = "on";

            string sv_logbans_text = "";
            if (sv_logbans.Text == "Off") sv_logbans_text = "off";
            else sv_logbans_text = "on";

            string cfg_script = Properties.Resources.server_cfg;
            cfg_script = cfg_script
                .Replace("{hostname}", $"{hostname.Text}")
                .Replace("{sv_lan}", $"{sv_lan_text}")
                .Replace("{sv_region}", $"{sv_region_text}")

                .Replace("{sv_password}", $"{sv_password.Text}")
                .Replace("{rcon_password}", $"{rcon_password.Text}")

                .Replace("{log}", $"{sv_log_text}")
                .Replace("{sv_logbans}", $"{}")
                .Replace("{sv_logecho}", $"{}")
                .Replace("{sv_logfile}", $"{}")
                .Replace("{sv_log_onefile}", $"{}")

                .Replace("{sv_rcon_banpenalty}", $"{}")
                .Replace("{sv_rcon_maxfailures}", $"{}")
                .Replace("{sv_rcon_minfailures}", $"{}")
                .Replace("{sv_rcon_minfailuretime}", $"{}")

                .Replace("{sv_minrate}", $"{}")
                .Replace("{sv_maxrate}", $"{}")
                .Replace("{decalfrequency}", $"{}")
                .Replace("{sv_maxupdaterate}", $"{}")
                .Replace("{sv_minupdaterate}", $"{}")

                .Replace("{mp_friendlyfire}", $"{}")
                .Replace("{mp_footsteps}", $"{}")
                .Replace("{mp_autoteambalance}", $"{}")
                .Replace("{mp_autokick}", $"{}")
                .Replace("{mp_flashlight}", $"{}")
                .Replace("{mp_tkpunish}", $"{}")
                .Replace("{mp_forcecamera}", $"{}")
                .Replace("{sv_alltalk}", $"{}")
                .Replace("{sv_pausable}", $"{}")
                .Replace("{sv_consistency}", $"{}")
                .Replace("{sv_cheats}", $"{}")
                .Replace("{sv_allowupload}", $"{}")
                .Replace("{sv_allowdownload}", $"{}")
                .Replace("{sv_maxspeed}", $"{}")
                .Replace("{mp_limitteams}", $"{}")
                .Replace("{mp_hostagepenalty}", $"{}")
                .Replace("{sv_voiceenable}", $"{}")
                .Replace("{mp_allowspectators}", $"{}")
                .Replace("{mp_timelimit}", $"{}")
                .Replace("{mp_chattime}", $"{}")
                .Replace("{sv_timeout}", $"{}")

                .Replace("{mp_freezetime}", $"{}")
                .Replace("{mp_roundtime}", $"{}")
                .Replace("{mp_startmoney}", $"{}")
                .Replace("{mp_c4timer}", $"{}")
                .Replace("{mp_fraglimit}", $"{}")
                .Replace("{mp_maxrounds}", $"{}")
                .Replace("{mp_winlimit}", $"{}")
                .Replace("{mp_playerid}", $"{}")
                .Replace("{mp_spawnprotectiontime}", $"{}")

                .Replace("{bot_quota}", $"{}")
                .Replace("{bot_quota_mode}", $"{}")
                .Replace("{bot_difficulty}", $"{}")
                .Replace("{bot_chatter}", $"{}")
                .Replace("{bot_auto_follow}", $"{}")
                .Replace("{bot_auto_vacate}", $"{}")
                .Replace("{bot_join_after_player}", $"{}")
                .Replace("{bot_defer_to_human}", $"{}")
                .Replace("{bot_allow_rogues}", $"{}")
                .Replace("{bot_walk}", $"{}")
                .Replace("{bot_join_team}", $"{}")
                .Replace("{bot_eco_limit}", $"{}")
                .Replace("{bot_all_weapons}", $"{}")
                .Replace("{bot_allow_grenades}", $"{}")
                .Replace("{bot_allow_pistols}", $"{}")
                .Replace("{bot_allow_sub_machine_guns}", $"{}")
                .Replace("{bot_allow_shotguns}", $"{}")
                .Replace("{bot_allow_rifles}", $"{}")
                .Replace("{bot_allow_snipers}", $"{}")
                .Replace("{bot_allow_machine_guns}", $"{}")
                );

            Core.SaveToFile(app.installPath + @"\cstrike\server.cfg", cfg_script);
        }
    }
}
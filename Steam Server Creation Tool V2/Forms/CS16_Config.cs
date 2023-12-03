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
            if (sv_logbans.Text == "Off") sv_logbans_text = "0";
            else sv_logbans_text = "1";

            string sv_logecho_text = "";
            if (sv_logecho.Text == "Off") sv_logecho_text = "0";
            else sv_logecho_text = "1";

            string sv_logfile_text = "";
            if (sv_logfile.Text == "Off") sv_logfile_text = "0";
            else sv_logfile_text = "1";

            string sv_log_onefile_text = "";
            if (sv_log_onefile.Text == "No") sv_log_onefile_text = "0";
            else sv_log_onefile_text = "1";

            string mp_friendlyfire_text = "";
            if (mp_friendlyfire.Text == "No") mp_friendlyfire_text = "0";
            else mp_friendlyfire_text = "1";

            string mp_footsteps_text = "";
            if (mp_footsteps.Text == "No") mp_footsteps_text = "0";
            else mp_footsteps_text = "1";

            string mp_autoteambalance_text = "";
            if (mp_autoteambalance.Text == "No") mp_autoteambalance_text = "0";
            else mp_autoteambalance_text = "1";

            string mp_autokick_text = "";
            if (mp_autokick.Text == "No") mp_autokick_text = "0";
            else mp_autokick_text = "1";

            string mp_flashlight_text = "";
            if (mp_flashlight.Text == "No") mp_flashlight_text = "0";
            else mp_flashlight_text = "1";

            string mp_tkpunish_text = "";
            if (mp_tkpunish.Text == "No") mp_tkpunish_text = "0";
            else mp_tkpunish_text = "1";

            string mp_forcecamera_text = "";
            if (mp_forcecamera.Text == "No") mp_forcecamera_text = "0";
            else mp_forcecamera_text = "1";

            string sv_alltalk_text = "";
            if (sv_alltalk.Text == "No") sv_alltalk_text = "0";
            else sv_alltalk_text = "1";

            string sv_pausable_text = "";
            if (sv_pausable.Text == "No") sv_pausable_text = "0";
            else sv_pausable_text = "1";

            string sv_consistency_text = "";
            if (sv_consistency.Text == "No") sv_consistency_text = "0";
            else sv_consistency_text = "1";

            string sv_cheats_text = "";
            if (sv_cheats.Text == "No") sv_cheats_text = "0";
            else sv_cheats_text = "1";

            string sv_allowupload_text = "";
            if (sv_allowupload.Text == "No") sv_allowupload_text = "0";
            else sv_allowupload_text = "1";

            string sv_allowdownload_text = "";
            if (sv_allowdownload.Text == "No") sv_allowdownload_text = "0";
            else sv_allowdownload_text = "1";

            string sv_voiceenable_text = "";
            if (sv_voiceenable.Text == "No") sv_voiceenable_text = "0";
            else sv_voiceenable_text = "1";

            string mp_allowspectators_text = "";
            if (mp_allowspectators.Text == "No") mp_allowspectators_text = "0";
            else mp_allowspectators_text = "1";

            string sv_timeout_text = "";
            switch(sv_timeout.Text)
            {
                case "15 Seconds":
                    sv_timeout_text = "15";
                    break;
                case "20 Seconds":
                    sv_timeout_text = "20";
                    break;
                case "25 Seconds":
                    sv_timeout_text = "25";
                    break;
                case "30 Seconds":
                    sv_timeout_text = "30";
                    break;
                case "35 Seconds":
                    sv_timeout_text = "35";
                    break;
                case "40 Seconds":
                    sv_timeout_text = "40";
                    break;
                case "45 Seconds":
                    sv_timeout_text = "45";
                    break;
                case "50 Seconds":
                    sv_timeout_text = "50";
                    break;
                case "55 Seconds":
                    sv_timeout_text = "55";
                    break;
                case "60 Seconds":
                    sv_timeout_text = "60";
                    break;
                case "65 Seconds":
                    sv_timeout_text = "65";
                    break;
                case "2 Minutes":
                    sv_timeout_text = "120";
                    break;
            }

            string mp_playerid_text = "";
            if (mp_playerid.Text == "No") mp_playerid_text = "0";
            else mp_playerid_text = "1";

            string bot_add_text = "";
            if (bot_add.Text == "No") bot_add_text = "0";
            else bot_add_text = "1";

            string bot_quota_mode_text = "";
            if (bot_quota_mode.Text == "Fill") bot_quota_mode_text = "fill";
            else bot_quota_mode_text = "normal";

            string bot_chatter_text = "";
            switch (bot_chatter.Text)
            {
                case "Off":
                    bot_chatter_text = "off";
                    break;
                case "Radio":
                    bot_chatter_text = "radio";
                    break;
                case "Minimal":
                    bot_chatter_text = "minimal";
                    break;
                case "Normal":
                    bot_chatter_text = "normal";
                    break;
            }

            string bot_auto_follow_text = "";
            if (bot_auto_follow.Text == "No") bot_auto_follow_text = "0";
            else bot_auto_follow_text = "1";

            string bot_auto_vacate_text = "";
            if (bot_auto_vacate.Text == "No") bot_auto_vacate_text = "0";
            else bot_auto_vacate_text = "1";

            string bot_join_after_player_text = "";
            if (bot_join_after_player.Text == "No") bot_join_after_player_text = "0";
            else bot_join_after_player_text = "1";

            string bot_defer_to_human_text = "";
            if (bot_defer_to_human.Text == "No") bot_defer_to_human_text = "0";
            else bot_defer_to_human_text = "1";

            string bot_allow_rogues_text = "";
            if (bot_allow_rogues.Text == "No") bot_allow_rogues_text = "0";
            else bot_allow_rogues_text = "1";

            string bot_walk_text = "";
            if (bot_walk.Text == "Run & Walk") bot_walk_text = "0";
            else bot_walk_text = "1";

            string bot_join_team_text = "";
            switch (bot_join_team.Text)
            {
                case "Any":
                    bot_join_team_text = "any";
                    break;
                case "Terrorist":
                    bot_join_team_text = "t";
                    break;
                case "Counter - Terrorist":
                    bot_join_team_text = "ct";
                    break;
            }

            string bot_allow_grenades_text = "";
            if (bot_allow_grenades.Text == "No") bot_allow_grenades_text = "0";
            else bot_allow_grenades_text = "1";

            string bot_allow_pistols_text = "";
            if (bot_allow_pistols.Text == "No") bot_allow_pistols_text = "0";
            else bot_allow_pistols_text = "1";

            string bot_allow_sub_machine_guns_text = "";
            if (bot_allow_sub_machine_guns.Text == "No") bot_allow_sub_machine_guns_text = "0";
            else bot_allow_sub_machine_guns_text = "1";

            string bot_allow_shotguns_text = "";
            if (bot_allow_shotguns.Text == "No") bot_allow_shotguns_text = "0";
            else bot_allow_shotguns_text = "1";

            string bot_allow_rifles_text = "";
            if (bot_allow_rifles.Text == "No") bot_allow_rifles_text = "0";
            else bot_allow_rifles_text = "1";

            string bot_allow_snipers_text = "";
            if (bot_allow_snipers.Text == "No") bot_allow_snipers_text = "0";
            else bot_allow_snipers_text = "1";

            string bot_allow_machine_guns_text = "";
            if (bot_allow_machine_guns.Text == "No") bot_allow_machine_guns_text = "0";
            else bot_allow_machine_guns_text = "1";

            string cfg_script = Properties.Resources.server_cfg;
            cfg_script = cfg_script
                .Replace("{hostname}", $"{hostname.Text}")
                .Replace("{sv_lan}", $"{sv_lan_text}")
                .Replace("{sv_region}", $"{sv_region_text}")

                .Replace("{sv_password}", $"{sv_password.Text}")
                .Replace("{rcon_password}", $"{rcon_password.Text}")

                .Replace("{log}", $"{sv_log_text}")
                .Replace("{sv_logbans}", $"{sv_logbans_text}")
                .Replace("{sv_logecho}", $"{sv_logecho_text}")
                .Replace("{sv_logfile}", $"{sv_logfile_text}")
                .Replace("{sv_log_onefile}", $"{sv_log_onefile_text}")

                .Replace("{sv_rcon_banpenalty}", $"{sv_rcon_banpenalty_combobox.Text}")
                .Replace("{sv_rcon_maxfailures}", $"{sv_rcon_maxfaliures.Value}")
                .Replace("{sv_rcon_minfailures}", $"{sv_rcon_minfaliures.Value}")
                .Replace("{sv_rcon_minfailuretime}", $"{sv_rcon_minfaliuretime.Text}")

                .Replace("{sv_minrate}", $"{sv_minrate.Value}")
                .Replace("{sv_maxrate}", $"{sv_maxrate.Value}")
                .Replace("{decalfrequency}", $"{decalfrequency.Value}")
                .Replace("{sv_maxupdaterate}", $"{sv_maxupdaterate.Value}")
                .Replace("{sv_minupdaterate}", $"{sv_minupdaterate.Value}")

                .Replace("{mp_friendlyfire}", $"{mp_friendlyfire_text}")
                .Replace("{mp_footsteps}", $"{mp_footsteps_text}")
                .Replace("{mp_autoteambalance}", $"{mp_autoteambalance_text}")
                .Replace("{mp_autokick}", $"{mp_autokick_text}")
                .Replace("{mp_flashlight}", $"{mp_flashlight_text}")
                .Replace("{mp_tkpunish}", $"{mp_tkpunish_text}")
                .Replace("{mp_forcecamera}", $"{mp_forcecamera_text}")
                .Replace("{sv_alltalk}", $"{sv_alltalk_text}")
                .Replace("{sv_pausable}", $"{sv_pausable_text}")
                .Replace("{sv_consistency}", $"{sv_consistency_text}")
                .Replace("{sv_cheats}", $"{sv_cheats_text}")
                .Replace("{sv_allowupload}", $"{sv_allowupload_text}")
                .Replace("{sv_allowdownload}", $"{sv_allowdownload_text}")
                .Replace("{sv_maxspeed}", $"{sv_maxspeed.Value}")
                .Replace("{mp_limitteams}", $"{mp_limitteams.Value}")
                .Replace("{mp_hostagepenalty}", $"{mp_hostagepenalty.Value}")
                .Replace("{sv_voiceenable}", $"{sv_voiceenable_text}")
                .Replace("{mp_allowspectators}", $"{mp_allowspectators_text}")
                .Replace("{mp_timelimit}", $"{mp_timelimit.Value}")
                .Replace("{mp_chattime}", $"{mp_chattime.Value}")
                .Replace("{sv_timeout}", $"{sv_timeout_text}")

                .Replace("{mp_freezetime}", $"{mp_freezetime.Value}")
                .Replace("{mp_roundtime}", $"{mp_roundtime.Value}")
                .Replace("{mp_startmoney}", $"{mp_startmoney.Value}")
                .Replace("{mp_c4timer}", $"{mp_c4timer.Value}")
                .Replace("{mp_fraglimit}", $"{mp_fraglimit.Value}")
                .Replace("{mp_maxrounds}", $"{mp_maxrounds.Value}")
                .Replace("{mp_winlimit}", $"{mp_winlimit.Value}")
                .Replace("{mp_playerid}", $"{mp_playerid_text}")
                .Replace("{mp_spawnprotectiontime}", $"{mp_spawnprotectiontime.Value}")

                .Replace("{bot_quota}", $"{bot_add_text}")
                .Replace("{bot_quota_mode}", $"{bot_quota.Value}")
                .Replace("{bot_difficulty}", $"{bot_quota_mode_text}")
                .Replace("{bot_chatter}", $"{bot_chatter_text}")
                .Replace("{bot_auto_follow}", $"{bot_auto_follow_text}")
                .Replace("{bot_auto_vacate}", $"{bot_auto_vacate_text}")
                .Replace("{bot_join_after_player}", $"{bot_join_after_player_text}")
                .Replace("{bot_defer_to_human}", $"{bot_defer_to_human_text}")
                .Replace("{bot_allow_rogues}", $"{bot_allow_rogues_text}")
                .Replace("{bot_walk}", $"{bot_walk_text}")
                .Replace("{bot_join_team}", $"{bot_join_team_text}")
                .Replace("{bot_eco_limit}", $"{bot_eco_limit.Value}")
                .Replace("{bot_allow_grenades}", $"{bot_allow_grenades_text}")
                .Replace("{bot_allow_pistols}", $"{bot_allow_pistols_text}")
                .Replace("{bot_allow_sub_machine_guns}", $"{bot_allow_sub_machine_guns_text}")
                .Replace("{bot_allow_shotguns}", $"{bot_allow_shotguns_text}")
                .Replace("{bot_allow_rifles}", $"{bot_allow_rifles_text}")
                .Replace("{bot_allow_snipers}", $"{bot_allow_snipers_text}")
                .Replace("{bot_allow_machine_guns}", $"{bot_allow_machine_guns_text}"
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
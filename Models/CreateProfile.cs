using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faCodeAndImap.Models
{
    public class CreateProfile
    {
        public string profile_name { get; set; }
        public string group_name { get; set; } = "All";
        public string browser_core { get; set; } = "chromium";
        public string browser_name { get; set; } = "Chrome";
        public string browser_version { get; set; } = "121.0.6167.140";
        public bool is_random_browser_version { get; set; } = false;
        public string raw_proxy { get; set; }
        public string startup_urls { get; set; } = "";
        public bool is_masked_font { get; set; } = true;
        public bool is_noise_canvas { get; set; } = false;
        public bool is_noise_webgl { get; set; } = false;
        public bool is_noise_client_rect { get; set; } = false;
        public bool is_noise_audio_context { get; set; } = true;
        public bool is_random_screen { get; set; } = true;
        public bool is_masked_webgl_data { get; set; } = true;
        public bool is_masked_media_device { get; set; } = true;
        public bool is_random_os { get; set; } = false;
        public string os { get; set; } = "Windows 11";
        public int webrtc_mode { get; set; } = 2;
    }

    public class ChangeProxyModel
    {
        public string profile_name { get; set; }
        public string raw_proxy { get; set; }
    }
}

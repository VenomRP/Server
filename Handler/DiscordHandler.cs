using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using GVRP.Module.Configurations;
using GVRP.Module.Logging;

namespace GVRP.Handler
{
    public class DiscordHandler
    {
        private string m_LiveWebhookURL = "https://discord.com/api/webhooks/931420765436379136/LtcXikkfvd47P67KitNMp0couPEDPkvNfXnWsQ9Fjc0VceqpLaEnZtGlywmf3QS8EfhM";
        //private string m_TestWebhookURL = "https://discord.com/api/webhooks/931420765436379136/LtcXikkfvd47P67KitNMp0couPEDPkvNfXnWsQ9Fjc0VceqpLaEnZtGlywmf3QS8EfhM";
        private string m_BanWebhookURL = "https://discord.com/api/webhooks/932343851753025556/dTn4ZJ6amOuWhGHwvc4A3xwqyOLqkYRjhwebMtXHzETh8uiX9xrvb7kfhBA1-Bqf37_K";
        private string m_ExceptionLoggerURL = "https://discord.com/api/webhooks/931233916461928519/1b1Wy4LDgTTRLXHE-45RvdVsUFl745WnuEjr-x3OLLLRO6U8WaobBbJzP7udJOsRh50A";
        private string m_KillWebhookURL = "https://discord.com/api/webhooks/931233833045606460/o9ci2I5nJzk7VT7vmnuG6Cj0sSsU5q1ZHHO_nk45wLOzzAtnDwZdaLJJE4xltyLW8ksC";
        private string m_SupportWebhookURL = "https://discord.com/api/webhooks/931233875043168336/G7MLDhpNt-x1ASxJBuRxvcYrJu4GHCpzHot7BLO1VfNSndhu2X7biMfqo4G2tKy8EjPm";
        private string m_ReviveWebhookURL = "https://discord.com/api/webhooks/931233875043168336/G7MLDhpNt-x1ASxJBuRxvcYrJu4GHCpzHot7BLO1VfNSndhu2X7biMfqo4G2tKy8EjPm";
        private string m_KickWebhookURL = "https://discord.com/api/webhooks/932097124613636176/6LnK8YC-lJU2SDAO0Q1fXpl-BHGxDnvz6tfbhrC7CSoHFLQqVxtEYxqJ2WdDf0GU1_t8";
        private string m_FeatureWebhookURL = "https://discord.com/api/webhooks/932099958969094215/hnlS-9y77804wIng_NQdHBKPhrQZciywx7siQsh1oXyxnXbfECUvOp3LJR7CBj5MAh1s";
        private string m_AutoshopWebhookURL = "https://discord.com/api/webhooks/932104416000086037/7x1yWvY32CyP5oV5nZ4ukx5egkJBYzV8PWEzGZmzgUHJOsZmoZ-WPbgde-hRJX2B2sFw";
        private string m_BankingWebhookURL = "https://discord.com/api/webhooks/932110114448625754/BeI4w4AkrQoQaAtYdRTTIi31rnE-ZwViI1Spjzh760sAywXmgP6uqevTHYxbtuTqYANT";
        private string m_AdminWebhookURL = "https://discord.com/api/webhooks/932315951817429024/MzzvRkOD9vs8rXgm2sHXsBbo8L2GsAxD6Jat9qnRyZ7t0kgSXpOaJubuf2KvXMgFSJdR";
        private string m_CoordWebhookURL = "https://discord.com/api/webhooks/932316127609126943/PBg_Mt12ZDP07NMl_sAo2a4Zs0TJFPYnMVeLr5WaXRrSNnOZNpRtU4rVtw1K3Hxg2OwS";
        private string m_FIBWebhookURL = "https://discord.com/api/webhooks/932342070251765770/whLWS8WhB_CuNwbGt9xPbXcLU5FYzLRRp9WcF9pgc9H4u3UG6IPdfxkrh9xIWcYNKx79";
        private string m_WorkstationWebhookURL = "https://discord.com/api/webhooks/932342154989277286/sDrqh23Zvpfo5e0vdoWcIheTqlI8rC228HrtTFmosvIf7ipDURTjaR0yRz0afTjbu42W";
        private string m_AnticheatWebhookURL = "https://discord.com/api/webhooks/933791311893508127/mys614IeRzQuTkzdTe5hibf-zRVf3uu5UaBfuuL0vGtg7zVtKSZR2ZfH9VJ5yUZuOEJU";

        public DiscordHandler()
        {
        }

        public enum Channels
        {
            FEATURE,
            REVIVE,
            KICK,
            BAN,
            SUPPORT,
            WORKSTATION,
            KILL,
            WEAPONLAB,
            METHLAB,
            AUTOSHOP,
            ANTICHEAT,
            SHOP,
            DUPING,
            FORUM,
            SERVERSTART,
            ADMIN,
            BANKING,
            BLITZER,
            FUELSTATION,
            AKTEN,
            BUSINESS,
            FRAKTION,
            COMPUTER,
            DEALER,
            EINREISE,
            FIB,
            FARMING,
            GANGWAR,
            INJURY,
            JAIL,
            LSC,
            MENU,
            NEWS,
            BLACKMONEY,
            SERVICE,
            PHONE,
            COORDS,
            EXCEPTION,
            DEFAULT


        }

        public void SendMessage(string p_Message, string p_Description = "", Channels channel = Channels.DEFAULT)
        {

            try
            {

                DiscordMessage l_Message = new DiscordMessage($"{p_Message}", p_Description);

                using (WebClient l_WC = new WebClient())
                {
                    l_WC.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    l_WC.Encoding = Encoding.UTF8;

                    string l_Upload = JsonConvert.SerializeObject(l_Message);

                    switch (channel)
                    {
                        case Channels.KILL:
                            l_WC.UploadString(m_KillWebhookURL, l_Upload);
                            break;
                        case Channels.BAN:
                            l_WC.UploadString(m_BanWebhookURL, l_Upload);
                            break;

                        case Channels.COORDS:
                            l_WC.UploadString(m_CoordWebhookURL, l_Upload);
                            break;

                        case Channels.ADMIN:
                            l_WC.UploadString(m_AdminWebhookURL, l_Upload);
                            break;

                        case Channels.BANKING:
                            l_WC.UploadString(m_BankingWebhookURL, l_Upload);
                            break;

                        case Channels.AUTOSHOP:
                            l_WC.UploadString(m_AutoshopWebhookURL, l_Upload);
                            break;

                        case Channels.FEATURE:
                            l_WC.UploadString(m_FeatureWebhookURL, l_Upload);
                            break;

                        case Channels.REVIVE:
                            l_WC.UploadString(m_ReviveWebhookURL, l_Upload);
                            break;

                        case Channels.KICK:
                            l_WC.UploadString(m_KickWebhookURL, l_Upload);
                            break;

                        case Channels.SUPPORT:
                            l_WC.UploadString(m_SupportWebhookURL, l_Upload);
                            break;

                        case Channels.ANTICHEAT:
                            l_WC.UploadString(m_AnticheatWebhookURL, l_Upload);
                            break;

                        case Channels.EXCEPTION:
                            l_WC.UploadString(m_ExceptionLoggerURL, l_Upload);
                            break;
                        case Channels.FIB:
                            l_WC.UploadString(m_FIBWebhookURL, l_Upload);
                            break;
                        case Channels.WORKSTATION:
                            l_WC.UploadString(m_WorkstationWebhookURL, l_Upload);
                            break;

                        case Channels.DEFAULT:
                            l_WC.UploadString(m_LiveWebhookURL, l_Upload);
                            break;
                        default:
                            l_WC.UploadString(m_LiveWebhookURL, l_Upload);
                            break;

                    }

                    /*if (Configuration.Instance.DevMode)
                        l_WC.UploadString(m_TestWebhookURL, l_Upload);
                    else
                        l_WC.UploadString(m_LiveWebhookURL, l_Upload);*/
                }
            }
            catch (Exception e)
            {
                Logger.Crash(e);
                // muss funken lol
                // grüße von monkaMC
            }
        }
    }

    public class DiscordMessage
    {
        public string content { get; private set; }
        public bool tts { get; private set; }
        public EmbedObject[] embeds { get; private set; }

        public DiscordMessage(string p_Message, string p_EmbedContent)
        {
            content = p_Message;
            tts = false;

            EmbedObject l_Embed = new EmbedObject(p_EmbedContent);
            embeds = new EmbedObject[] { l_Embed };
        }
    }

    public class EmbedObject
    {
        public string title { get; private set; }
        public string description { get; private set; }

        public EmbedObject(string p_Desc)
        {
            title = DateTime.Now.ToString();
            description = p_Desc;
        }
    }
}

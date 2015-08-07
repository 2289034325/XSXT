using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BIANMA
{
    /// <summary>
    /// 扩展条码信息
    /// </summary>
    class TTiaomaExtend : ICloneable
    {
        public int idex;
        //public int khidex;
        public XTCONSTS.TIAOMA_XINJIU xj;
        public TTiaoma tiaoma;
        public short shuliang;


        public object Clone()
        {
            TTiaomaExtend ct = new TTiaomaExtend()
            {
                idex = idex,
                //khidex = khidex,
                xj = xj,
                tiaoma = new TTiaoma
                {
                    kuanhaoid = tiaoma.kuanhaoid,
                    tiaoma = tiaoma.tiaoma,
                    gyskuanhao = tiaoma.gyskuanhao,
                    yanse = tiaoma.yanse,
                    chima = tiaoma.chima,
                    jinjia = tiaoma.jinjia,
                    shoujia = tiaoma.shoujia,
                    caozuorenid = tiaoma.caozuorenid,
                    charushijian = tiaoma.charushijian,
                    xiugaishijian = tiaoma.xiugaishijian
                },
                shuliang = shuliang
            };

            return ct;
        }

        public XElement ToXml()
        {
            XElement xt = new XElement("TTiaomaExtend");
            xt.Add(new XElement("idex") { Value = idex.ToString() });
            xt.Add(new XElement("xj") { Value = ((byte)xj).ToString() });
            XElement Ntiaoma = new XElement("tiaoma");
            Ntiaoma.Add(new XElement("id") { Value = tiaoma.id.ToString() });
            Ntiaoma.Add(new XElement("tiaoma") { Value = tiaoma.tiaoma });
            Ntiaoma.Add(new XElement("gysid") { Value = tiaoma.gysid.ToString() });
            Ntiaoma.Add(new XElement("gyskuanhao") { Value = tiaoma.gyskuanhao });
            Ntiaoma.Add(new XElement("yanse") { Value = tiaoma.yanse });
            Ntiaoma.Add(new XElement("chima") { Value = tiaoma.chima });
            Ntiaoma.Add(new XElement("jinjia") { Value = tiaoma.jinjia.ToString() });
            Ntiaoma.Add(new XElement("shoujia") { Value = tiaoma.shoujia.ToString() });
            Ntiaoma.Add(new XElement("caozuorenid") { Value = tiaoma.caozuorenid.ToString() });
            Ntiaoma.Add(new XElement("charushijian") { Value = tiaoma.charushijian.ToString() });
            Ntiaoma.Add(new XElement("xiugaishijian") { Value = tiaoma.xiugaishijian.ToString() });
            xt.Add(Ntiaoma);
            xt.Add(new XElement("shuliang") { Value = shuliang.ToString() });

            return xt;
        }

        public static TTiaomaExtend FromXml(XElement xml)
        {
            TTiaomaExtend tx = new TTiaomaExtend();

            tx.idex = int.Parse(xml.Element("idex").Value);
            tx.xj = (XTCONSTS.TIAOMA_XINJIU)(byte.Parse(xml.Element("xj").Value));
            tx.tiaoma = new TTiaoma
            {
                id = int.Parse(xml.Element("tiaoma").Element("id").Value),
                tiaoma = xml.Element("tiaoma").Element("tiaoma").Value,
                gysid = int.Parse(xml.Element("tiaoma").Element("gysid").Value),
                gyskuanhao = xml.Element("tiaoma").Element("gyskuanhao").Value,
                yanse = xml.Element("tiaoma").Element("yanse").Value,
                chima = xml.Element("tiaoma").Element("chima").Value,
                jinjia = decimal.Parse(xml.Element("tiaoma").Element("jinjia").Value),
                shoujia = decimal.Parse(xml.Element("tiaoma").Element("shoujia").Value),
                caozuorenid = int.Parse(xml.Element("tiaoma").Element("caozuorenid").Value),
                charushijian = DateTime.Parse(xml.Element("tiaoma").Element("charushijian").Value),
                xiugaishijian = DateTime.Parse(xml.Element("tiaoma").Element("xiugaishijian").Value)
            };
            tx.shuliang = short.Parse(xml.Element("shuliang").Value);

            return tx;
        }
    }


    class TKuanhaoExtend
    {
        public int idex;
        public XTCONSTS.KUANHAO_XINJIU xj;
        public TKuanhao kuanhao;
        public List<TTiaomaExtend> tms;

        public TKuanhaoExtend()
        {
            tms = new List<TTiaomaExtend>();
        }

        public XElement ToXml()
        {
            XElement xk = new XElement("TKuanhaoExtend");

            xk.Add(new XElement("idex") { Value = idex.ToString() });
            xk.Add(new XElement("xj") { Value = ((byte)xj).ToString() });
            XElement Nkuanhao = new XElement("kuanhao");
            Nkuanhao.Add(new XElement("id") { Value = kuanhao.id.ToString() });
            Nkuanhao.Add(new XElement("kuanhao") { Value = kuanhao.kuanhao });
            Nkuanhao.Add(new XElement("xingbie") { Value = kuanhao.xingbie.ToString() });
            Nkuanhao.Add(new XElement("leixing") { Value = kuanhao.leixing.ToString() });
            Nkuanhao.Add(new XElement("pinming") { Value = kuanhao.pinming });
            Nkuanhao.Add(new XElement("beizhu") { Value = kuanhao.beizhu });
            Nkuanhao.Add(new XElement("caozuorenid") { Value = kuanhao.caozuorenid.ToString() });
            xk.Add(Nkuanhao);
            XElement Ntms = new XElement("tms");
            foreach (TTiaomaExtend tex in tms)
            {
                Ntms.Add(tex.ToXml());
            }
            xk.Add(Ntms);

            return xk;
        }

        public static TKuanhaoExtend[] FromXml(string xmlPath)
        {
            XElement doc = XElement.Load(xmlPath);
            List<TKuanhaoExtend> ks = new List<TKuanhaoExtend>();
            List<XElement> xmls = doc.Elements("TKuanhaoExtend").ToList();
            foreach (XElement xml in xmls)
            {
                TKuanhaoExtend kx = new TKuanhaoExtend
                {
                    idex = int.Parse(xml.Element("idex").Value),
                    xj = (XTCONSTS.KUANHAO_XINJIU)byte.Parse(xml.Element("xj").Value.ToString()),
                    kuanhao = new TKuanhao
                    {
                        id = int.Parse(xml.Element("kuanhao").Element("id").Value),
                        kuanhao = xml.Element("kuanhao").Element("kuanhao").Value,
                        leixing = byte.Parse(xml.Element("kuanhao").Element("leixing").Value),
                        xingbie = byte.Parse(xml.Element("kuanhao").Element("xingbie").Value),
                        pinming = xml.Element("kuanhao").Element("pinming").Value,
                        caozuorenid = int.Parse(xml.Element("kuanhao").Element("caozuorenid").Value),
                        beizhu = xml.Element("kuanhao").Element("beizhu").Value
                    },
                    tms = xml.Element("tms").Elements("TTiaomaExtend").Select(r => TTiaomaExtend.FromXml(r)).ToList()
                };

                ks.Add(kx);
            }

            return ks.ToArray();
        }
    }
}

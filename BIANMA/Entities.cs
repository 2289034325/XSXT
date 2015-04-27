using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tool.DB.JCSJ;

namespace BIANMA
{
    /// <summary>
    /// 扩展条码信息
    /// </summary>
    class TTiaomaExtend : ICloneable
    {
        public int idex;
        public int khidex;
        public XTCONSTS.TIAOMA_XINJIU xj;
        public TTiaoma tiaoma;
        public short shuliang;


        public object Clone()
        {
            TTiaomaExtend ct = new TTiaomaExtend()
            {
                idex = idex,
                khidex = khidex,
                xj = xj,
                tiaoma = new TTiaoma
                {
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

        public string ToXml()
        {
            XElement xt = new XElement("TTiaomaExtend");
            xt.Add(new XElement("idex") { Value = idex.ToString() });
            xt.Add(new XElement("khindex") { Value = khidex.ToString() });
            xt.Add(new XElement("xj") { Value = xj.ToString() });
            XElement Ntiaoma = new XElement("tiaoma");
            Ntiaoma.Add(new XElement("id") { Value = tiaoma.id.ToString() });
            Ntiaoma.Add(new XElement("tiaoma") { Value = tiaoma.tiaoma });
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

            return xt.ToString();
        }

        public TTiaomaExtend FromXml(XElement xml)
        {
            TTiaomaExtend tx = new TTiaomaExtend();

            tx.idex = int.Parse(xml.Element("idex").Value);
            tx.khidex = int.Parse(xml.Element("khindex").Value);
            tx.xj = (XTCONSTS.TIAOMA_XINJIU)(byte.Parse(xml.Element("xj").Value));
            tx.tiaoma = new TTiaoma
            {
                id = int.Parse(xml.Element("tiaoma").Element("id").Value),
                tiaoma = xml.Element("tiaoma").Element("tiaoma").Value,
                gyskuanhao = xml.Element("tiaoma").Element("tiaoma").Value,
                yanse = xml.Element("tiaoma").Element("tiaoma").Value,
                chima = xml.Element("tiaoma").Element("tiaoma").Value,
                jinjia = decimal.Parse(xml.Element("tiaoma").Element("tiaoma").Value),
                shoujia = decimal.Parse(xml.Element("tiaoma").Element("tiaoma").Value),
                caozuorenid = int.Parse(xml.Element("tiaoma").Element("tiaoma").Value),
                charushijian = DateTime.Parse(xml.Element("tiaoma").Element("tiaoma").Value),
                xiugaishijian = DateTime.Parse(xml.Element("tiaoma").Element("tiaoma").Value)
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
        //public List<TTiaomaExtend> tms;

        public TKuanhaoExtend()
        {
            //tms = new List<TTiaomaExtend>();
        }

        public string ToXml()
        {
            XElement xk = new XElement("TKuanhaoExtend");

            xk.Add(new XElement("idex") { Value = idex.ToString() });
            xk.Add(new XElement("xj") { Value = xj.ToString() });
            XElement Nkuanhao = new XElement("kuanhao");
            Nkuanhao.Add(new XElement("kuanhao") { Value = kuanhao.kuanhao });
            Nkuanhao.Add(new XElement("xingbie") { Value = kuanhao.xingbie.ToString() });
            Nkuanhao.Add(new XElement("leixing") { Value = kuanhao.leixing.ToString() });
            Nkuanhao.Add(new XElement("pinming") { Value = kuanhao.pinming });
            Nkuanhao.Add(new XElement("caozuorenid") { Value = kuanhao.caozuorenid.ToString() });
            xk.Add(Nkuanhao);

            return xk.ToString();
        }

        public TKuanhaoExtend FromXml(XElement xml)
        {
            TKuanhaoExtend kx = new TKuanhaoExtend();

            kx.idex = int.Parse(xml.Element("idex").Value);
            kx.xj = (XTCONSTS.KUANHAO_XINJIU)Enum.Parse(typeof(XTCONSTS.KUANHAO_XINJIU), xml.Element("xj").Value);
            kx.kuanhao = new TKuanhao
            {
                id = int.Parse(xml.Element("id").Value),
                leixing = byte.Parse(xml.Element("idex").Value),
                xingbie = byte.Parse(xml.Element("idex").Value),
                pinming = xml.Element("idex").Value,
                caozuorenid = int.Parse(xml.Element("idex").Value)
            };

            return kx;
        }
    }
}

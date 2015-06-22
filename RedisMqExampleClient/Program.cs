﻿using System;
using RedisMqExample;
using ServiceStack.Messaging;
using ServiceStack.Redis;
using ServiceStack.Redis.Messaging;

namespace RedisMqExampleClient
{
    class Program
    {
        private static void Main(string[] args)
        {
            var redisFactory = new PooledRedisClientManager("localhost:6800");
            var mqServer = new RedisMqServer(redisFactory, retryCount: 2);

            mqServer.Start(); //Starts listening for messages

            var uniqueCallbackQ = "mq:c1" + ":" + Guid.NewGuid().ToString("N");
            while (true)
            {
                using (var mqClient = mqServer.CreateMessageQueueClient())
                {
                    
                    var clientMsg = new Message<IndexerRequest>(new IndexerRequest { Id = "71925", ObjectKey = 71925, Type = "video", Action = "create" })
                    {
                        ReplyTo = uniqueCallbackQ
                    };
                    mqClient.Publish(clientMsg);

                    var clientMsg2 = new Message<IndexerRequestBulk>(new IndexerRequestBulk
                    {
                        Ids = new string[] {"71925",
"71924",
"71923",
"71922",
"71921",
"71920",
"71919",
"71918",
"71917",
"71916",
"71915",
"71914",
"71913",
"71912",
"71911",
"71910",
"71909",
"71908",
"71907",
"71906",
"71905",
"71904",
"71903",
"71902",
"71901",
"71900",
"71899",
"71898",
"71897",
"71896",
"71895",
"71894",
"71893",
"71892",
"71891",
"71890",
"71889",
"71888",
"71887",
"71886",
"71885",
"71884",
"71883",
"71882",
"71881",
"71880",
"71879",
"71878",
"71877",
"71876",
"71875",
"71874",
"71873",
"71872",
"71871",
"71870",
"71869",
"71868",
"71867",
"71866",
"71865",
"71864",
"71863",
"71862",
"71861",
"71860",
"71859",
"71858",
"71857",
"71856",
"71855",
"71854",
"71853",
"71852",
"71851",
"71850",
"71849",
"71848",
"71847",
"71846",
"71845",
"71844",
"71843",
"71842",
"71841",
"71840",
"71839",
"71838",
"71837",
"71836",
"71835",
"71834",
"71833",
"71832",
"71831",
"71830",
"71829",
"71828",
"71827",
"71826",
"71825",
"71824",
"71823",
"71822",
"71821",
"71820",
"71819",
"71818",
"71817",
"71816",
"71815",
"71814",
"71813",
"71812",
"71811",
"71810",
"71809",
"71808",
"71807",
"71806",
"71805",
"71804",
"71803",
"71802",
"71801",
"71800",
"71799",
"71798",
"71797",
"71796",
"71795",
"71794",
"71793",
"71792",
"71791",
"71790",
"71789",
"71788",
"71787",
"71786",
"71785",
"71784",
"71783",
"71782",
"71781",
"71780",
"71779",
"71778",
"71777",
"71776",
"71775",
"71774",
"71773",
"71772",
"71771",
"71770",
"71769",
"71768",
"71767",
"71766",
"71765",
"71764",
"71763",
"71762",
"71761",
"71760",
"71759",
"71758",
"71757",
"71756",
"71755",
"71754",
"71753",
"71752",
"71751",
"71750",
"71749",
"71748",
"71747",
"71746",
"71745",
"71744",
"71743",
"71742",
"71741",
"71740",
"71739",
"71738",
"71737",
"71736",
"71735",
"71734",
"71733",
"71732",
"71731",
"71730",
"71729",
"71728",
"71727",
"71726",
"71725",
"71724",
"71723",
"71722",
"71721",
"71720",
"71719",
"71718",
"71717",
"71716",
"71715",
"71714",
"71713",
"71712",
"71711",
"71710",
"71709",
"71708",
"71707",
"71706",
"71705",
"71704",
"71703",
"71702",
"71701",
"71700",
"71699",
"71698",
"71697",
"71696",
"71695",
"71694",
"71693",
"71692",
"71691",
"71690",
"71689",
"71688",
"71687",
"71686",
"71685",
"71684",
"71683",
"71682",
"71681",
"71680",
"71679",
"71678",
"71677",
"71676",
"71675",
"71674",
"71673",
"71672",
"71671",
"71670",
"71669",
"71668",
"71667",
"71666",
"71665",
"71664",
"71663",
"71662",
"71661",
"71660",
"71659",
"71658",
"71657",
"71656",
"71655",
"71654",
"71653",
"71652",
"71651",
"71650",
"71649",
"71648",
"71647",
"71646",
"71645",
"71644",
"71643",
"71642",
"71641",
"71640",
"71639",
"71638",
"71637",
"71636",
"71635",
"71634",
"71633",
"71632",
"71631",
"71630",
"71629",
"71628",
"71627",
"71626",
"71625",
"71624",
"71623",
"71622",
"71621",
"71620",
"71619",
"71618",
"71617",
"71616",
"71615",
"71614",
"71613",
"71612",
"71611",
"71610",
"71609",
"71608",
"71607",
"71606",
"71605",
"71604",
"71603",
"71602",
"71601",
"71600",
"71599",
"71598",
"71597",
"71596",
"71595",
"71594",
"71593",
"71592",
"71591",
"71590",
"71589",
"71588",
"71587",
"71586",
"71585",
"71584",
"71583",
"71582",
"71581",
"71580",
"71579",
"71578",
"71577",
"71576",
"71575",
"71574",
"71573",
"71572",
"71571",
"71570",
"71569",
"71568",
"71567",
"71566",
"71565",
"71564",
"71563",
"71562",
"71561",
"71560",
"71559",
"71558",
"71557",
"71556",
"71555",
"71554",
"71553",
"71552",
"71551",
"71550",
"71549",
"71548",
"71547",
"71546",
"71545",
"71544",
"71543",
"71542",
"71541",
"71540",
"71539",
"71538",
"71537",
"71536",
"71535",
"71534",
"71533",
"71532",
"71531",
"71530",
"71529",
"71528",
"71527",
"71526",
"71525",
"71524",
"71523",
"71522",
"71521",
"71520",
"71519",
"71518",
"71517",
"71516",
"71515",
"71514",
"71513",
"71512",
"71511",
"71510",
"71509",
"71508",
"71507",
"71506",
"71505",
"71504",
"71503",
"71502",
"71501",
"71500",
"71499",
"71498",
"71497",
"71496",
"71495",
"71494",
"71493",
"71492",
"71491",
"71490",
"71489",
"71488",
"71487",
"71486",
"71485",
"71484",
"71483",
"71482",
"71481",
"71480",
"71479",
"71478",
"71477",
"71476",
"71475",
"71474",
"71473",
"71472",
"71471",
"71470",
"71469",
"71468",
"71467",
"71466",
"71465",
"71464",
"71463",
"71462",
"71461",
"71460",
"71459",
"71458",
"71457",
"71456",
"71455",
"71454",
"71453",
"71452",
"71451",
"71450",
"71449",
"71448",
"71447",
"71446",
"71445",
"71444",
"71443",
"71442",
"71441",
"71440",
"71439",
"71438",
"71437",
"71436",
"71435",
"71434",
"71433",
"71432",
"71431",
"71430",
"71429",
"71428",
"71427",
"71426"}, Type = "video", Action = "create" })
                    {
                        ReplyTo = uniqueCallbackQ
                    };
                    mqClient.Publish(clientMsg2);
                   // var response = mqClient.Get(uniqueCallbackQ, new TimeSpan(0, 0, 1, 0)).ToMessage<IndexerResponse>();
                    //Console.WriteLine("Got response back: {0}", response.GetBody().Result);
                }

                Console.WriteLine("Client running.  Press any key to terminate...");
                Console.ReadLine(); //Block the server from exiting (i.e. if running inside Console App)
            }
        }
    }
}

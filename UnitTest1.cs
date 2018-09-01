using System;
using Xunit;
using Amazon.S3;
using Amazon.Runtime;
using System.Threading.Tasks;
using Amazon.S3.Model;

namespace s3select
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var client = new AmazonS3Client();
            var response = await client.SelectObjectContentAsync(new SelectObjectContentRequest()
            {
                Bucket = "dion-s3lab",
                Key = "test.json",
                ExpressionType = ExpressionType.SQL,
                Expression = "select * from S3Object s where s.COMPANY = 'AMAZON'",
                InputSerialization = new InputSerialization()
                {
                    JSON = new JSONInput()
                    {
                        JsonType = JsonType.Lines
                    }
                },
                OutputSerialization = new OutputSerialization()
                {
                    JSON = new JSONOutput()
                }
            });
            Console.WriteLine(response.Payload);
        }
    }
}

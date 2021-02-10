﻿using CardCost.Core.Entities;
using System.Collections.Generic;

namespace CardCost.Infrastructure.Data.MockData
{
    public class AccessUserMockData
    {
        public List<AccessUser> AccessUser { get; set; }
        public static AccessUserMockData Current { get; } = new AccessUserMockData();

        public AccessUserMockData()
        {
            AccessUser = new List<AccessUser>
            {
                new AccessUser()
                {
                    Id = 1,
                    Username = "user1",
                    PasswordHash = new byte[64] { 34,240,80,184,3,181,109,5,128,154,76,61,80,158,79,161,56,15,251,191,108,150,25,159,154,216,209,63,219,45,16,21,214,126,60,109,255,21,144,84,143,178,208,166,209,228,21,105,213,15,21,142,185,163,32,12,30,130,252,235,123,47,213,246 },
                    PasswordSalt = new byte[128]{ 225, 106, 159, 116, 244, 116, 51, 250, 12, 232, 206, 67, 136, 163, 224, 49, 161, 67, 175, 140, 190, 30, 31, 248, 224, 140, 194, 202, 249, 255, 245, 191, 173, 109, 215, 10, 71, 89, 77, 184, 181, 128, 52, 171, 255, 160, 213, 50, 77, 77, 111, 45, 171, 97, 81, 87, 253, 90, 31, 40, 133, 227, 191, 161, 88, 89, 85, 212, 200, 65, 233, 79, 182, 71, 80, 178, 23, 213, 222, 23, 84, 239, 82, 232, 92, 121, 58, 198, 219, 192, 32, 55, 9, 48, 44, 216, 252, 58, 29, 220, 13, 19, 90, 218, 149, 115, 182, 215, 151, 177, 215, 102, 192, 121, 21, 158, 231, 115, 209, 165, 168, 102, 157, 7, 132, 185, 43, 205 }
                },
                new AccessUser()
                {
                    Id = 2,
                    Username = "user2",
                    PasswordHash = new byte[64] { 34,240,80,184,3,181,109,5,128,154,76,61,80,158,79,161,56,15,251,191,108,150,25,159,154,216,209,63,219,45,16,21,214,126,60,109,255,21,144,84,143,178,208,166,209,228,21,105,213,15,21,142,185,163,32,12,30,130,252,235,123,47,213,246 },
                    PasswordSalt = new byte[128]{ 225, 106, 159, 116, 244, 116, 51, 250, 12, 232, 206, 67, 136, 163, 224, 49, 161, 67, 175, 140, 190, 30, 31, 248, 224, 140, 194, 202, 249, 255, 245, 191, 173, 109, 215, 10, 71, 89, 77, 184, 181, 128, 52, 171, 255, 160, 213, 50, 77, 77, 111, 45, 171, 97, 81, 87, 253, 90, 31, 40, 133, 227, 191, 161, 88, 89, 85, 212, 200, 65, 233, 79, 182, 71, 80, 178, 23, 213, 222, 23, 84, 239, 82, 232, 92, 121, 58, 198, 219, 192, 32, 55, 9, 48, 44, 216, 252, 58, 29, 220, 13, 19, 90, 218, 149, 115, 182, 215, 151, 177, 215, 102, 192, 121, 21, 158, 231, 115, 209, 165, 168, 102, 157, 7, 132, 185, 43, 205 }
                },
                new AccessUser()
                {
                    Id = 3,
                    Username = "user3",
                    PasswordHash = new byte[64] { 34,240,80,184,3,181,109,5,128,154,76,61,80,158,79,161,56,15,251,191,108,150,25,159,154,216,209,63,219,45,16,21,214,126,60,109,255,21,144,84,143,178,208,166,209,228,21,105,213,15,21,142,185,163,32,12,30,130,252,235,123,47,213,246 },
                    PasswordSalt = new byte[128]{ 225, 106, 159, 116, 244, 116, 51, 250, 12, 232, 206, 67, 136, 163, 224, 49, 161, 67, 175, 140, 190, 30, 31, 248, 224, 140, 194, 202, 249, 255, 245, 191, 173, 109, 215, 10, 71, 89, 77, 184, 181, 128, 52, 171, 255, 160, 213, 50, 77, 77, 111, 45, 171, 97, 81, 87, 253, 90, 31, 40, 133, 227, 191, 161, 88, 89, 85, 212, 200, 65, 233, 79, 182, 71, 80, 178, 23, 213, 222, 23, 84, 239, 82, 232, 92, 121, 58, 198, 219, 192, 32, 55, 9, 48, 44, 216, 252, 58, 29, 220, 13, 19, 90, 218, 149, 115, 182, 215, 151, 177, 215, 102, 192, 121, 21, 158, 231, 115, 209, 165, 168, 102, 157, 7, 132, 185, 43, 205 }
                }
            };
        }
    }
}

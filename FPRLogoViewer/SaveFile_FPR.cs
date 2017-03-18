/* hacked up version for logo viewer because I don't want to import all of LibFirePro in an incomplete state */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FPRLogoViewer
{
	/// <summary>
	/// Fire Pro Wrestling Returns save file.
	/// </summary>
	public class SaveFile_FPR
	{
		/// <summary>
		/// Raw Fire Pro Wrestling Returns save data, without the checksum block.
		/// </summary>
		public byte[] RawSaveData = new byte[0xDE000];

		/*
	     * An extremely special thanks goes out to Jason Blackhart, for
	     * providing us with the information behind FPR's checksumming.
	     * 
	     * http://www.fpwarena.com/forum/viewtopic.php?f=5&t=376&start=50#p19154
	     */
		#region Checksum Table
		/// <summary>
		/// Checksum table used for Fire Pro Wrestling Returns save files.
		/// </summary>
		public uint[] ChecksumTable = {
			0x93B1F778,
			0x68F043BB,
			0x70ABDBD3,
			0xBF3419CB,
			0x0902EBDF,
			0x655FC1D7,
			0x5161AA94,
			0xF61BB9E9,
			0xAE14AEAC,
			0xC4F9D20C,
			0x7B8E2324,
			0x51EAB1D1,
			0x84E448C1,
			0xD6C94FCD,
			0x8D50F089,
			0xBFCF7A19,
			0xCCAE0346,
			0x2C1C51D1,
			0x6B02FB06,
			0x7135CB95,
			0x07F0679E,
			0x9781300B,
			0x33426B22,
			0xD9CB9F5A,
			0xF6663D6E,
			0x28C486B1,
			0x48EEAAA1,
			0xA87D2DBE,
			0x990E8F9D,
			0x31F12C38,
			0x4B216188,
			0xCE79F056,
			0x3324A64E,
			0x41563B55,
			0x1B39791C,
			0x7D2BA0F5,
			0x43260AE6,
			0x2B7F0BFC,
			0xDBD41BE2,
			0x264037B2,
			0x8BD0840B,
			0xFE3B3664,
			0xECCDB0A0,
			0x79A5ECE2,
			0x0C201EA2,
			0x0D959401,
			0xED43E159,
			0x67873A19,
			0x065320D0,
			0xE8DB4087,
			0xC1919754,
			0x2254D92C,
			0xFCE414F9,
			0x609A90EC,
			0x8856FB15,
			0x1BB8C231,
			0xAD93C2C3,
			0x859E2066,
			0xA46D7561,
			0x03A02F7C,
			0x1B5B3412,
			0xAAF6C868,
			0xB5F5B03D,
			0xC93A97A2,
			0x8779B20C,
			0x60EDA0A8,
			0x9C4994EE,
			0xA1F2B579,
			0x726BC516,
			0x7610011B,
			0x7B0849FA,
			0xFA758115,
			0x9CED37D4,
			0xFE2E86F5,
			0xB10D3A24,
			0x86B034CC,
			0x08FD112C,
			0x495206AD,
			0xE2770E73,
			0x35D14832,
			0xF5D89A43,
			0xE9CB9BF7,
			0xECA2B02B,
			0x3944751C,
			0xE5FA5E7D,
			0xAD239EC7,
			0xF22A47D1,
			0x02B6B3A0,
			0x99202480,
			0xA82AA753,
			0x54EE3E2A,
			0x42143D12,
			0x1248F531,
			0x29EB9011,
			0xB4093C3B,
			0xE98C8C08,
			0x90AF1AB4,
			0xC3B572B4,
			0xF2DA2B49,
			0x2A8A5756,
			0x96D11E6F,
			0x4613A532,
			0x2FFD35DA,
			0x73BB9911,
			0xE36BC706,
			0xC2D2C3C0,
			0xCC4EC1B2,
			0x770C8A8F,
			0x797B205F,
			0x8A01A5D3,
			0x6BEC79D5,
			0x27ABA364,
			0x993E729F,
			0x2EEB631F,
			0xED33468A,
			0xB4049D65,
			0xC430452A,
			0x7F1E589B,
			0x71C05155,
			0x8EC471A8,
			0xBA0F62A6,
			0x8F671B7A,
			0x5A6F03FC,
			0x66D95982,
			0x7ED7D3F8,
			0xADD28533,
			0x485F0582,
			0x2E6FCD86,
			0x4FC5E044,
			0x6BAEB179,
			0x1CEC402D,
			0x17F3868B,
			0xAF5813F0,
			0x9B86F642,
			0xF8B3DD83,
			0x92127DA6,
			0x5F4A34A1,
			0x4C28EDC3,
			0x3C904548,
			0x4EBAEC2B,
			0x5F9B4D3B,
			0xD1A07171,
			0x8AA22081,
			0x3F174AAF,
			0xF285A6E4,
			0xB93D9901,
			0xC2455973,
			0x94965208,
			0x9787C900,
			0xD78ABF68,
			0x051618A3,
			0xBFE4FC4A,
			0x105E7E36,
			0x3B557BDA,
			0xB4F2C5D6,
			0x70EF81CA,
			0x5E06CE68,
			0x36AAA8CE,
			0x71F60B12,
			0x98E35B1E,
			0xC2BD03BE,
			0x59D85DF7,
			0x1C7FD29B,
			0x6A2D421A,
			0xBD00A59B,
			0x756AF34B,
			0xD72A42F5,
			0x557A2ED4,
			0x0F8A7EA5,
			0x9B2E05FF,
			0x01D3C5E7,
			0x0AB85BA0,
			0xBB5B97C0,
			0x1C316A89,
			0x3E990575,
			0x7B133F13,
			0x00AD3712,
			0x89BF3B9B,
			0x6CD8E9E5,
			0xD9F89403,
			0x6000EA00,
			0xB366D32D,
			0xAE2D9CBA,
			0x94155484,
			0x9C0F762E,
			0xACF3C973,
			0x647585BA,
			0x5E56B7EB,
			0xB4D7E682,
			0xC373F7E2,
			0x2FCD4EEB,
			0x28E836CE,
			0xEB968320,
			0x8B33762E,
			0xF192E091,
			0x21388A02,
			0xC0C8D56F,
			0xD3BF9E4E,
			0xCA616431,
			0xBDF4AD9A,
			0xF52BA511,
			0xAEE50975,
			0x1B184390,
			0xAB07D7ED,
			0x8BBCFDEE,
			0x6CB28F19,
			0x86D226B3,
			0xDDA08190,
			0xC3B72629,
			0x9E734BEF,
			0xEBEDF6DF,
			0x832C6457,
			0x1D99A828,
			0x15B494EC,
			0x6C06DC9A,
			0x0F567957,
			0x5C204C8F,
			0xE2430445,
			0x68FA41A7,
			0x310DF9E6,
			0x7F491C44,
			0x562D736F,
			0x82E6CE0D,
			0xDC7E5E98,
			0xC850606C,
			0x02BFFB1E,
			0x9B276C10,
			0x3E146042,
			0xB8B2A16B,
			0xB785F549,
			0xD25A4435,
			0xCA7EF8FA,
			0x102DA9E7,
			0x874DFA23,
			0x8A5DBE41,
			0x31A86014,
			0xD0BE81C5,
			0xC124E222,
			0x644B8539,
			0x63BF0F26,
			0x3BA17129,
			0xF857C7FC,
			0x3F828063,
			0x9230C004,
			0xD0540279,
			0xFB7302A4,
			0x3E9FDA42,
			0x2FA96BC3,
			0x5193FE5A,
			0xDD442B50,
			0xC27FFB9D,
			0xEA1649B9,
			0xBF5B6EB0,
			0xEED81D75,
			0x6A408B78,
			0xB5A5D37A
		};
		#endregion

		/// <summary>
		/// First block of checksum data.
		/// </summary>
		public uint[] SaveChecksums1 = new uint[888];
		/// <summary>
		/// Second block of checksum data.
		/// </summary>
		public byte[] SaveChecksums2 = new byte[1024];
		/// <summary>
		/// Checksum of the checksums.
		/// </summary>
		public uint SaveChecksum3 = 0;

		#region Save Data Contents
		/// <summary>
		/// The save only includes 6 logos
		/// </summary>
		public LogoData[] Logos = new LogoData[6];

		#endregion

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SaveFile_FPR() {
			for (int i = 0; i < Logos.Length; i++) {
				this.Logos[i] = new LogoData();
			}
		}

		#region Loading
		/// <summary>
		/// Loads data from a raw Fire Pro Wrestling Returns save file into member structures.
		/// </summary>
		/// <param name="path">Path to raw Fire Pro Wrestling Returns save file.</param>
		/// The raw save file typically has a name of "BISLPM-66082", "BASLUS-21702", or "BESLES-55041".
		public void Load_RawSave(string path) {
			// Load main save file contents (no checksum block) into RawSaveData.
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			br.Read(this.RawSaveData, 0, this.RawSaveData.Length);
			br.Close();

			// Load data from save file into various structures.
			MemoryStream ms = new MemoryStream(this.RawSaveData);
			br = new BinaryReader(ms);

			// logos
			ms.Seek(0xC5810, SeekOrigin.Begin);
			for (int i = 0; i < this.Logos.Length; i++ ) {
				this.Logos[i].Load_Memory(br.ReadBytes(0x4110));
			}

			br.Close();
		}

		/// <summary>
		/// Loads data from an EMS Memory Linker (.psu) file into member structures.
		/// </summary>
		/// <param name="path">Path to .psu save file.</param>
		public void Load_PSU(string path) {
			// raw save data starts at 0x800 in a psu file
			FileStream fs = new FileStream(path, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			fs.Seek(0x800,SeekOrigin.Begin);
			this.RawSaveData = br.ReadBytes(this.RawSaveData.Length);
			br.Close();

			MemoryStream ms = new MemoryStream(this.RawSaveData);
			br = new BinaryReader(ms);

			ms.Seek(0xC5810,SeekOrigin.Begin);
			for (int i = 0; i < this.Logos.Length; i++) {
				this.Logos[i].Load_Memory(br.ReadBytes(0x4110));
			}

			br.Close();

		}
		#endregion

		#region Saving
		/// <summary>
		/// Calculates checksums and writes Fire Pro Wrestling Returns save data to a file.
		/// </summary>
		/// <param name="path"></param>
		public void Save_Raw(string path) {
			// Store updated logos into RawSaveData.
			MemoryStream ms = new MemoryStream(this.RawSaveData);
			BinaryWriter mbw = new BinaryWriter(ms);

			mbw.Seek(0xC5810, SeekOrigin.Begin);
			for (int i = 0; i < this.Logos.Length; i++ ) {
				// write logo data back
			}

			mbw.Close();

			// Write raw save data, calculate checksums, and write checksum data.
			using (FileStream fs = new FileStream(path, FileMode.Create)) {
				using (BinaryWriter bw = new BinaryWriter(fs)) {
					bw.Write(this.RawSaveData);
					CalculateSaveChecksum();

					// write checksums
					// Part 1
					for (int i = 0; i < this.SaveChecksums1.Length; i++) {
						bw.Write(this.SaveChecksums1[i]);
					}
					// Part 2
					for (int i = 0; i < this.SaveChecksums2.Length; i++) {
						bw.Write(this.SaveChecksums2[i]);
					}
					// Part 3
					bw.Write(this.SaveChecksum3);

					bw.Flush();
					bw.Close();
				}
			}
		}


		#endregion

		/// <summary>
		/// Calculate checksum data.
		/// </summary>
		/// This code was originally written by Jason Blackhart.
		private void CalculateSaveChecksum() {
			// part 1
			for (int y = 0; y < SaveChecksums1.Length; y++) {
				uint sum1 = 0;
				for (int x = 0; x < 1024; x++) {
					sum1 = (sum1 << 8) ^ (ChecksumTable[(sum1 >> 24) ^ (this.RawSaveData[(y * 1024) + x])]);
				}
				SaveChecksums1[y] = sum1;
			}

			// part 2
			for (int y = 0; y < SaveChecksums2.Length; y++) {
				byte sum2 = 0;
				for (int x = 0; x < SaveChecksums1.Length; x++) {
					sum2 = (byte)(sum2 ^ this.RawSaveData[(x * 1024) + y]);
				}
				SaveChecksums2[y] = sum2;
			}

			// part 3
			SaveChecksum3 = 0;
			for (int x = 0; x < 1024; x++) {
				SaveChecksum3 = (SaveChecksum3 << 8) ^ (ChecksumTable[((SaveChecksum3 >> 24) ^ SaveChecksums2[x])]);
			}
		}
	}
}

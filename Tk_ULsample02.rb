# Tk_ULsample.rb
# 2016/09/26
#
# UserLocalAPIにコマンドを送って
# 動作やセンサーに対応した反応をする。
# "C:"がコマンド識別用の頭文字とする。

require "tk"		# GUIを使用するためのライブラリ
require "net/http"	# httpを扱うためのライブラリ
require "json"		# JSONを扱うためのライブラリ
require "uri"		# uriを扱うためのライブラリ
require "open-uri"

# メッセージ取得のクラス
class GetMessage
	# mess取得メソッド
	def GetMess(mess)
		api_key = "1459e8f5f23200343636"
		uri = URI.parse(URI.encode("https://chatbot-api.userlocal.jp/api/chat?message=#{mess}&key=#{api_key}"))

		json_hash = self.GetJson(uri)
		res = self.PerseJson(json_hash)

		return res
	end

	# Json取得メソッド
	def GetJson(uri)
		json = Net::HTTP.get(uri)
		hash = JSON.parse(json)
		return hash
	end

	# Json解析メソッド
	def PerseJson(json_hash)
		result = json_hash.fetch("result")
		return result
	end
end

# 文字色変更を簡単にするためのクラス
class String
	def green
		"\e[32m#{self.chomp}\e[0m"
	end

	def blue
		"\e[34m#{self.chomp}\e[0m"
	end
end

# タグを処理するクラス
class GetTag
	@@M_word = ""

	def ScanTag(mess)
		case mess		
			when /(.*)(\d:)(.*)/
				@@M_word = ($1+$2)
				return $3.split("|")

			when /(.*)(E:)(.*)/
				@@M_word = ""
				return $3.split("|")

			else
				@@M_word = ""
				return mess.split("|")
		end
	end

	def GetMw
		return @@M_word
	end

end

# ループ処理で会話をし続ける
getMessage = GetMessage.new
getTag = GetTag.new

loop{
	tag = getTag.GetMw

	puts("[takuto]\n".blue)
	input = tag + gets.to_s.chomp
	puts(input.green)

	puts("[UL]\n".green)
	output = getMessage.GetMess(input)
	output = getTag.ScanTag(output)
	puts(output)
}
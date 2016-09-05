# ms2016.01
未来創造展2017プログラム開発用

git使い方

リモートの情報取得
git fetch

全てのファイルをインデックスに登録
git add .

変更したファイルをgitに保存
git commit -m "コメント"

リモートの情報をローカルへ反映
git merge origin/master

fetch mergeを一度に行う
git pull origin master

ローカルブランチをリモートブランチへ更新
git push origin {ローカルのhoge}:{リモートのhoge}

リモートブランチ取得
git clone {リモートのアドレス}

リモートディレクトリ確認
git remote

リモートブランチ確認
git branch -a

ブランチ作成
git push --set-upstream origin {ブランチ名}

ブランチの移動
git checkout {ブランチ名}
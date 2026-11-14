# FlyingScoreOffset

[![Build and Release](https://github.com/denpadokei/FlyingScoreOffset/actions/workflows/build-and-release.yml/badge.svg)](https://github.com/denpadokei/FlyingScoreOffset/actions/workflows/build-and-release.yml)

カット時に飛ぶスコア表示 (フライングスコア) の到達位置を、設定した座標ぶんずらす MOD です。

## 機能

- `FlyingObjectEffect.InitAndPresent` を Harmony の Prefix でフックする
- 対象が `FlyingScoreEffect` のときだけ処理する (他のフライングオブジェクトは変更しない)
- 移動先 `targetPos` に設定の `Offset` (x / y / z) を加算する
- オフセットは BSIPA の設定ファイルで管理する (ゲーム内 UI は無い)
- プラグイン無効化時に Harmony パッチを解除する

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.20.0 |
| 依存 MOD | BSIPA 4.0.0 以降 |

## インストール

1. Beat Saber を 1.20.0 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/FlyingScoreOffset/releases) から `FlyingScoreOffset-1.0.0-bs1.20.0.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## 使い方

ゲーム内に設定画面はありません。`UserData/FlyingScoreOffset.json` を開き、`Offset` の `x` / `y` / `z` を書き換えてゲームを再起動してください。既定値は `(0, 0, 0)` で、この場合は何も変わりません。

## 設定

| 項目 | 型 | 既定値 | 説明 |
| --- | --- | --- | --- |
| `Offset` | Vector3 | (0, 0, 0) | フライングスコアの移動先 `targetPos` に加算するオフセット。`x` / `y` / `z` のマップとして保存される |

設定は `UserData/FlyingScoreOffset.json` に保存されます。

## ビルド

```powershell
git clone https://github.com/denpadokei/FlyingScoreOffset.git
cd FlyingScoreOffset
dotnet build .\FlyingScoreOffset\FlyingScoreOffset.csproj -c Release
```

`BeatSaberDir` (または `GameDirectory`) に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。

GitHub Actions の `build-and-release.yml` が push ごとにビルドし、`X.X.X` 形式のタグを push するとリリースを作成します。

## ライセンス

MIT License (`LICENSE`)

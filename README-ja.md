# Net35TestSample
このソリューションは .NET 3.5 で Taskを使う為のサンプルです。
VisualStudio2017 で .NET 3.5 / C#7.3 で開発する際に使用します。

# 構成

## Net35TestSample
async Main で始めるコンソールのプロジェクトです。

## Net35TestSampleBase
コンソールを纏める為に ILMerge してるので テスト用に分離しているプロジェクトです。

## Net35TestSampleBaseTests
Net35TestSampleBase のテストです。
↑ ※VisualStudio 2017 15.9.2 でテストエクスプローラからテスト単体を選択しても実行できない
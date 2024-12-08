# SpeedHash Benchmark

Tento projekt byl vytvořen jako úkol pro předmět **Základy kryptografie a zabezpečení systémů (ZKZBS)**.

## O projektu

SpeedHash Benchmark je nástroj navržený pro porovnání výkonu různých hashovacích algoritmů. Implementovány jsou následující algoritmy:

- MD5
- SHA-1
- SHA-256
- SHA-512
- Blake2b

## Implementace algoritmů

- **MD5, SHA-1, SHA-256, SHA-512**: Tyto algoritmy využívají výchozí implementace z knihovny **System.Security.Cryptography** v .NET.
- **Blake2b**: Implementace je založena na knihovně **NSec.Cryptography**, která využívá **libsodium** pro optimalizovaný výkon.

## Jak projekt funguje

Program provádí benchmarky na sadě předdefinovaných datových velikostí (např. 10, 20, 50, 100 bajtů) po dobu 20 sekund pro každý algoritmus a velikost dat. Výsledky jsou zobrazovány v konzoli a také ukládány do CSV souboru pro další analýzu.

## Spouštění programu

Pro spuštění projektu jednoduše spusťte hlavní soubor programu. Výsledky benchmarků budou automaticky generovány a uloženy.

## Ukládání výsledků

Výsledky testů se ukládají v CSV formátu, nazvaném jako `BenchmarkResults_<datum_a_čas>.csv`, což umožňuje snadné sledování a porovnání výsledků v externích nástrojích.

## Systémové požadavky

- .NET 9.0
- C# 13.0

## Závislosti

Projekt používá následující knihovny:
- **Spectre.Console**: Pro formátování a zobrazení výstupu v konzoli.
- **NSec.Cryptography**: Pro implementaci Blake2b hashovacího algoritmu.
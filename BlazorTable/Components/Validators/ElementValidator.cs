using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using BlazorTable.Components.Models;

namespace BlazorTable.Components.Validators;

public class ElementValidator
{
    private static readonly Regex MacAddressRegex =
        new(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$", RegexOptions.Compiled);

    public static bool Validate(string value, ElementType type)
    {
        return type.Title switch
        {
            "IPv4" => ValidateIPv4(value),
            "IPv6" => ValidateIPv6(value),
            "Mac" => ValidateMac(value),
            "Text" => ValidateText(value),
            _ => false
        };
    }

    private static bool ValidateIPv4(string value)
    {
        return IPAddress.TryParse(value, out var address) && address.AddressFamily == AddressFamily.InterNetwork;
    }

    private static bool ValidateIPv6(string value)
    {
        return IPAddress.TryParse(value, out var address) && address.AddressFamily == AddressFamily.InterNetworkV6;
    }

    private static bool ValidateMac(string value)
    {
        return MacAddressRegex.IsMatch(value);
    }

    private static bool ValidateText(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}
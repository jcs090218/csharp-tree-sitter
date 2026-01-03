const std = @import("std");

pub fn main() !void {
    var i: usize = 1;
    while (i <= 16) : (i += 1) { // The ':(i += 1)' is the while loop continuation expression
        if (i % 15 == 0) {
            std.log.info("ZiggZagg", .{});
        } else if (i % 3 == 0) {
            std.log.info("Zigg", .{});
        } else if (i % 5 == 0) {
            std.log.info("Zagg", .{});
        } else {
            // Using "{d}" format specifier for decimal integers
            std.log.info("{d}", .{i});
        }
    }
}

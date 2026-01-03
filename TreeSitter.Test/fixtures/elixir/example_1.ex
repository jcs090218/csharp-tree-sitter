defmodule Geometry do
  # Clause 1: handles a rectangle tuple {width, height}
  def area({:rectangle, w, h}) do
    w * h
  end

  # Clause 2: handles a circle tuple {radius} only if the radius is a number
  def area({:circle, r}) when is_number(r) do
    3.14 * r * r
  end
end

# Example usage:
IO.puts(Geometry.area({:rectangle, 2, 3}))
IO.puts(Geometry.area({:circle, 3}))

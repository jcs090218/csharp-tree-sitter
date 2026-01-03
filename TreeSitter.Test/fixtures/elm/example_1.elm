module Main exposing (..)

import Browser
import Html exposing (Html, button, div, text)
import Html.Events exposing (onClick)

-- MAIN
main =
    Browser.sandbox { init = init, update = update, view = view }

-- MODEL
-- The Model is the state of your application.
type alias Model = Int

init : Model
init =
    0

-- UPDATE
-- Update is a way to update your state based on messages (actions).
-- Define the possible messages using a custom type.
type Msg
    = Increment
    | Decrement

update : Msg -> Model -> Model
update msg model =
    case msg of
        Increment ->
            model + 1

        Decrement ->
            model - 1

-- VIEW
-- The view function turns your model into HTML.
view : Model -> Html Msg
view model =
    div []
        [ button [ onClick Decrement ] [ text "-" ]
        , div [] [ text (toString model) ]
        , button [ onClick Increment ] [ text "+" ]
        ]

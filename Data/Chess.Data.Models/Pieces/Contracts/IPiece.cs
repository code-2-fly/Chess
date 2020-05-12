﻿namespace Chess.Data.Models.Pieces.Contracts
{
    using System;

    using Chess.Common.Enums;

    public interface IPiece : ICloneable
    {
        string Name { get; }

        Color Color { get; }

        char Symbol { get; }

        Position Position { get; set; }

        bool IsFirstMove { get; set; }

        bool IsLastMove { get; set; }

        bool IsMovable { get; set; }

        void IsMoveAvailable(Square[][] matrix);

        void Attacking(Square[][] matrix);

        bool Move(Position toPosition, Square[][] boardMatrix);

        bool Take(Position toPosition, Square[][] boardMatrix);
    }
}

﻿namespace Chess.Data.Models.Pieces
{
    using Chess.Common;
    using Chess.Common.Enums;
    using Chess.Web.Models;

    public class Knight : Piece
    {
        public Knight(Color color)
            : base(color)
        {
        }

        public override char Symbol => Constants.KnightSymbol;

        public override int Points => Constants.KnightPoints;

        public override void IsMoveAvailable(Square[][] matrix)
        {
            if (this.MoveCheck(-1, -2, matrix) ||
                this.MoveCheck(-1, 2, matrix) ||
                this.MoveCheck(1, -2, matrix) ||
                this.MoveCheck(1, 2, matrix) ||
                this.MoveCheck(-2, -1, matrix) ||
                this.MoveCheck(-2, 1, matrix) ||
                this.MoveCheck(2, -1, matrix) ||
                this.MoveCheck(2, 1, matrix))
            {
                this.IsMovable = true;
                return;
            }

            this.IsMovable = false;
        }

        public override void Attacking(Square[][] matrix)
        {
            this.AttackedSquares(-1, -2, matrix);
            this.AttackedSquares(-1, 2, matrix);
            this.AttackedSquares(1, -2, matrix);
            this.AttackedSquares(1, 2, matrix);
            this.AttackedSquares(-2, -1, matrix);
            this.AttackedSquares(-2, 1, matrix);
            this.AttackedSquares(2, -1, matrix);
            this.AttackedSquares(2, 1, matrix);
        }

        public override bool Move(Position to, Square[][] matrix, int turn, Move move)
        {
            if (to.File == this.Position.File - 1 && to.Rank == this.Position.Rank - 2)
            {
                return true;
            }

            if (to.File == this.Position.File + 1 && to.Rank == this.Position.Rank - 2)
            {
                return true;
            }

            if (to.File == this.Position.File - 1 && to.Rank == this.Position.Rank + 2)
            {
                return true;
            }

            if (to.File == this.Position.File + 1 && to.Rank == this.Position.Rank + 2)
            {
                return true;
            }

            if (to.File == this.Position.File - 2 && to.Rank == this.Position.Rank - 1)
            {
                return true;
            }

            if (to.File == this.Position.File - 2 && to.Rank == this.Position.Rank + 1)
            {
                return true;
            }

            if (to.File == this.Position.File + 2 && to.Rank == this.Position.Rank - 1)
            {
                return true;
            }

            if (to.File == this.Position.File + 2 && to.Rank == this.Position.Rank + 1)
            {
                return true;
            }

            return false;
        }

        public override bool Take(Position to, Square[][] matrix, int turn, Move move)
        {
            return this.Move(to, matrix, turn, move);
        }

        public override object Clone()
        {
            return new Knight(this.Color)
            {
                Position = this.Position.Clone() as Position,
                IsMovable = this.IsMovable,
            };
        }

        private void AttackedSquares(int offsetY, int offsetX, Square[][] matrix)
        {
            if (Position.IsInBoard(this.Position.File + offsetX, this.Position.Rank + offsetY))
            {
                matrix[this.Position.Rank + offsetY][this.Position.File + offsetX].IsAttacked.Add(this);
            }
        }

        private bool MoveCheck(int offsetY, int offsetX, Square[][] matrix)
        {
            if (Position.IsInBoard(this.Position.File + offsetX, this.Position.Rank + offsetY))
            {
                var square = matrix[this.Position.Rank + offsetY][this.Position.File + offsetX];

                if (square.Piece == null || square.Piece.Color != this.Color)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

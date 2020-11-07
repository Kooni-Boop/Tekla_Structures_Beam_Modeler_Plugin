using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using BeamModelPlugin.Tools;
using Tekla.Structures;
using Tekla.Structures.Plugins;
using TSModel = Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Catalogs;
using Tekla.Structures.Dialog;
using Tekla.Structures.Dialog.UIControls;
using Tekla.Structures.Drawing;
using Tekla.Structures.Filtering.Categories;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.Operations;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = Tekla.Structures.Geometry3d.Point;
using Vector = Tekla.Structures.Geometry3d.Vector;

namespace BeamModelPlugin
{
    [Plugin("BeamModelPlugin")]
    [PluginUserInterface("BeamModelPlugin.Main")]
    public class MainPlugin : PluginBase
    {
        private readonly StructuresData _data;

        private TSModel.Model Model { get; }

        public MainPlugin(StructuresData data)
        {
            Model = new TSModel.Model();
            _data = data;
        }

        public override bool Run(List<InputDefinition> input)
        {
            if (input.Count > 0)
            {
                var array = input[0].GetInput() as ArrayList;
                var pt1 = array[0] as Point;
                var pt2 = array[1] as Point;

                if (pt2 != null)
                {
                    try
                    {
                        var slab = InsertSlab(pt1, pt2);
                        RotateSlab(slab, pt1, pt2);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }

            return true;
        }

        private void InsertRebar()
        {
            TSModel.Model model = new TSModel.Model();
            TSModel.Beam testModel = new TSModel.Beam();
            testModel.Class = "11";
            testModel.Name = "GIRDER";
            testModel.Material.MaterialString = "C24";
        }

        private void BeamForm(Point pt1, Point pt2)
        {
            double lh = _data.LeftHeight;
            double rh = _data.RightHeight;
            if (lh > 0 || rh > 0)
            {
                if (lh > rh)
                {
                    InsertBeam(_data.TopWidth, lh, pt1, pt2);
                }

                if (rh > lh)
                {
                    InsertBeam(_data.TopWidth, rh, pt1, pt2);
                }

                if (rh == lh)
                {
                    InsertBeam(_data.TopWidth, rh, pt1, pt2);
                }
            }
            else
            {
                InsertBeam(_data.TopWidth, _data.CentHeight, pt1, pt2);
            }
        }

        private TSModel.ContourPlate RotateSlab(TSModel.ContourPlate slab, Point pt1, Point pt2)
        {
            CoordinateSystem c1 = new CoordinateSystem(pt1, null, null);
            CoordinateSystem c2 = new CoordinateSystem(pt2, null, null);

            if (!Operation.MoveObject(slab, c1, c2))
            {
                MessageBox.Show("rotation failed");
            }

            return slab;
        }

        private TSModel.ContourPlate SlabTest()
        {
            TSModel.ContourPlate slab = new TSModel.ContourPlate();
            TSModel.ContourPoint pt1 = new TSModel.ContourPoint(new Point(-500, 0, 0),
                new TSModel.Chamfer(30, 30, TSModel.Chamfer.ChamferTypeEnum.CHAMFER_LINE));
            TSModel.ContourPoint pt2 = new TSModel.ContourPoint(new Point(-500, 0, 500),
                new TSModel.Chamfer(30, 30, TSModel.Chamfer.ChamferTypeEnum.CHAMFER_LINE));
            TSModel.ContourPoint pt3 = new TSModel.ContourPoint(new Point(0, 0, 500),
                new TSModel.Chamfer(30, 30, TSModel.Chamfer.ChamferTypeEnum.CHAMFER_LINE));
            TSModel.ContourPoint pt4 = new TSModel.ContourPoint(new Point(0, 0, 0),
                new TSModel.Chamfer(30, 30, TSModel.Chamfer.ChamferTypeEnum.CHAMFER_LINE));

            slab.Name = "SLAB";
            slab.Profile.ProfileString = "700";
            slab.Material.MaterialString = "C24";
            slab.Class = "4";
            slab.Position.Depth = TSModel.Position.DepthEnum.BEHIND;
            slab.Contour.AddContourPoint(pt1);
            slab.Contour.AddContourPoint(pt2);
            slab.Contour.AddContourPoint(pt3);
            slab.Contour.AddContourPoint(pt4);

            if (!slab.Insert())
            {
                MessageBox.Show("Slab insert failed.", "slab");
            }
            else
            {
                Model.CommitChanges();
            }

            return slab;
        }

        private TSModel.ContourPlate InsertSlab(Point p1, Point p2)
        {
            TSModel.ContourPlate slab = new TSModel.ContourPlate();
            double dst = PointTool.DistanceTo(p1, p2);

            if (Math.Abs(PointTool.AngleTo(p1, p2) - 0) < 180)
            {
                slab.Position.Depth = TSModel.Position.DepthEnum.BEHIND;
            }

            if (Math.Abs(PointTool.AngleTo(p1, p2) - 180) < 180)
            {
                slab.Position.Depth = TSModel.Position.DepthEnum.FRONT;
            }

            slab.Name = "SLAB";
            slab.Profile.ProfileString = dst.ToString();
            slab.Material.MaterialString = "C24";
            slab.Class = "4";

            var lh = _data.LeftHeight;
            var tlc = _data.TopLeftCut;
            var tw = _data.TopWidth;
            var trc = _data.TopRightCut;
            var twc = _data.TopWedgeCut;
            var rh = _data.RightHeight;
            var bwc = _data.BotWedgeCut;
            var ch = _data.CentHeight;

            Point rp1 = new Point(0, 0, 0);
            Point rp2 = new Point(0, 0, 0);
            Point rp3 = new Point(0, 0, 0);
            Point rp4 = new Point(0, 0, 0);
            Point rp5 = new Point(0, 0, 0);
            Point rp6 = new Point(0, 0, 0);
            Point rp7 = new Point(0, 0, 0);
            Point rp8 = new Point(0, 0, 0);

            Point cp1 = new TSModel.ContourPoint(rp1, null);
            Point cp2 = new TSModel.ContourPoint(rp2, null);
            Point cp3 = new TSModel.ContourPoint(rp3, null);
            Point cp4 = new TSModel.ContourPoint(rp4, null);
            Point cp5 = new TSModel.ContourPoint(rp5, null);
            Point cp6 = new TSModel.ContourPoint(rp6, null);
            Point cp7 = new TSModel.ContourPoint(rp7, null);
            Point cp8 = new TSModel.ContourPoint(rp8, null);

            //todo: new axis vairbles.

            ArrayList cp = new ArrayList();

            var chamtyp = TSModel.Chamfer.ChamferTypeEnum.CHAMFER_LINE;

            TSModel.ContourPoint chamfIns(Point cfp, double x)
            {
                TSModel.ContourPoint chamfer = new TSModel.ContourPoint(cfp, new TSModel.Chamfer(x, x, chamtyp));
                return chamfer;
            }

            if (tlc != 0 || trc != 0) //상단 내깎기 둘중에 하나 존재
            {
                if (tlc != 0 && trc == 0) //상단 우측 내깎기 있음
                {
                    if ((ch - lh) == (ch - rh))
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }

                    if (lh != 0 && rh == 0) //상단 좌측 내깎기 있고 왼쪽 높이도 정상적으로 입력됨.
                    {
                        rp1 = new Point(p1.X - (tw + tlc) / 2, p1.Y, p1.Z);
                        rp2 = new Point(p1.X - (tw + tlc) / 2, p1.Y, p1.Z + lh);
                        rp3 = new Point(p1.X - (tw + tlc) / 2 + tlc, p1.Y, p1.Z + lh);
                        rp4 = new Point(p1.X - (tw + tlc) / 2 + tlc, p1.Y, p1.Z + ch);
                        rp5 = new Point(p1.X + (tw + tlc) / 2, p1.Y, p1.Z + ch);
                        rp6 = new Point(p1.X + (tw + tlc) / 2, p1.Y, p1.Z);
                        cp1 = new TSModel.ContourPoint(rp1, null);
                        cp2 = new TSModel.ContourPoint(rp2, null);
                        cp3 = new TSModel.ContourPoint(rp3, null);
                        cp4 = new TSModel.ContourPoint(rp4, null);
                        cp5 = new TSModel.ContourPoint(rp5, null);
                        cp6 = new TSModel.ContourPoint(rp6, null);
                        if (twc > 0 || bwc > 0)
                        {
                            if (twc > 0)
                            {
                                cp3 = chamfIns(rp3, twc);
                            }

                            if (bwc > 0)
                            {
                                cp1 = chamfIns(rp1, bwc);
                                cp6 = chamfIns(rp6, bwc);
                            }
                        }
                    }

                    if (lh == 0 && rh != 0)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }

                    if (lh != 0 && rh != 0)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }
                }

                if (tlc == 0 && trc != 0) //상단 우측 내깎기 있음.
                {
                    if (Math.Abs(ch - lh) < 0.1 && Math.Abs(ch - rh) < 0.1)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }

                    if (lh != 0 && rh == 0)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }

                    if (lh == 0 && rh != 0) //상단 우측 내깎끼 있고 우측 높이도 정상적으로 입력됨.
                    {
                        rp1 = new Point(p1.X - (tw + trc) / 2, p1.Y, p1.Z);
                        rp2 = new Point(p1.X - (tw + trc) / 2, p1.Y, p1.Z + ch);
                        rp3 = new Point(p1.X + (tw + trc) / 2 - trc, p1.Y, p1.Z + ch);
                        rp4 = new Point(p1.X + (tw + trc) / 2 - trc, p1.Y, p1.Z + rh);
                        rp5 = new Point(p1.X + (tw + trc) / 2, p1.Y, p1.Z + rh);
                        rp6 = new Point(p1.X + (tw + trc) / 2, p1.Y, p1.Z);
                        cp1 = new TSModel.ContourPoint(rp1, null);
                        cp2 = new TSModel.ContourPoint(rp2, null);
                        cp3 = new TSModel.ContourPoint(rp3, null);
                        cp4 = new TSModel.ContourPoint(rp4, null);
                        cp5 = new TSModel.ContourPoint(rp5, null);
                        cp6 = new TSModel.ContourPoint(rp6, null);
                        if (twc > 0 || bwc > 0)
                        {
                            if (twc > 0)
                            {
                                cp4 = chamfIns(rp4, twc);
                            }

                            if (bwc > 0)
                            {
                                cp1 = chamfIns(rp1, bwc);
                                cp6 = chamfIns(rp6, bwc);
                            }
                        }
                    }

                    if (lh != 0 && rh != 0)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }
                }

                if (tlc != 0 && trc != 0) //상단 내깎기 양쪽 모두 존재.
                {
                    if (Math.Abs(ch - lh) < 0.1 && Math.Abs(ch - rh) < 0.1)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }

                    if (lh != 0 && rh == 0)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }

                    if (lh == 0 && rh != 0)
                    {
                        MessageBox.Show("잘못된 입력입니다. 입력된 수치를 확인하고 다시 시도해 주세요.", "input error");
                    }

                    if (lh != 0 && rh != 0) //상단 내깎기 양쪽 모두 존재하고 양쪽 높이도 정상적으로 입력됨.
                    {
                        rp1 = new Point(p1.X - ((tw + tlc + trc) / 2), p1.Y, p1.Z);
                        rp2 = new Point(p1.X - ((tw + tlc + trc) / 2), p1.Y, p1.Z + lh);
                        rp3 = new Point(p1.X - ((tw + tlc + trc) / 2) + tlc, p1.Y, p1.Z + lh);
                        rp4 = new Point(p1.X - ((tw + tlc + trc) / 2) + tlc, p1.Y, p1.Z + ch);
                        rp5 = new Point(p1.X + ((tw + tlc + trc) / 2) - trc, p1.Y, p1.Z + ch);
                        rp6 = new Point(p1.X + ((tw + tlc + trc) / 2) - trc, p1.Y, p1.Z + rh);
                        rp7 = new Point(p1.X + ((tw + tlc + trc) / 2), p1.Y, p1.Z + rh);
                        rp8 = new Point(p1.X + ((tw + tlc + trc) / 2), p1.Y, p1.Z);
                        cp1 = new TSModel.ContourPoint(rp1, null);
                        cp2 = new TSModel.ContourPoint(rp2, null);
                        cp3 = new TSModel.ContourPoint(rp3, null);
                        cp4 = new TSModel.ContourPoint(rp4, null);
                        cp5 = new TSModel.ContourPoint(rp5, null);
                        cp6 = new TSModel.ContourPoint(rp6, null);
                        cp7 = new TSModel.ContourPoint(rp7, null);
                        cp8 = new TSModel.ContourPoint(rp8, null);
                        if (twc > 0 || bwc > 0)
                        {
                            if (twc > 0)
                            {
                                cp3 = chamfIns(rp3, twc);
                                cp6 = chamfIns(rp6, twc);
                            }

                            if (bwc > 0)
                            {
                                cp1 = chamfIns(rp1, bwc);
                                cp8 = chamfIns(rp8, bwc);
                            }
                        }
                    }
                }
            }

            if (tlc == 0 && trc == 0) //상단 내깎기 양쪽 다 없고, 양쪽 높이도 입력된게 없음.
            {
                if (lh == 0 && rh == 0)
                {
                    rp1 = new Point(p1.X - (tw / 2), p1.Y, p1.Z);
                    rp2 = new Point(p1.X - (tw / 2), p1.Y, p1.Z + ch);
                    rp3 = new Point(p1.X + (tw / 2), p1.Y, p1.Z + ch);
                    rp4 = new Point(p1.X + (tw / 2), p1.Y, p1.Z);
                    cp1 = new TSModel.ContourPoint(rp1, null);
                    cp2 = new TSModel.ContourPoint(rp2, null);
                    cp3 = new TSModel.ContourPoint(rp3, null);
                    cp4 = new TSModel.ContourPoint(rp4, null);
                    if (twc > 0 || bwc > 0)
                    {
                        if (bwc > 0)
                        {
                            cp1 = chamfIns(rp1, bwc);
                            cp4 = chamfIns(rp4, bwc);
                        }
                    }
                }
            }

            try
            {
                cp.Add(cp1);
                cp.Add(cp2);
                cp.Add(cp3);
                cp.Add(cp4);
                if (rp5.X != 0)
                {
                    cp.Add(cp5);
                    cp.Add(cp6);
                    if (rp7.X != 0)
                    {
                        cp.Add(cp7);
                        cp.Add(cp8);
                    }
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("입력값 형식이 잘못되었습니다. 다시 확인해 주세요.\n" + e, "invalid input");
            }

            slab.Contour.ContourPoints = cp;

            if (!slab.Insert())
            {
                //ignore;
            }
            else
            {
                Model.CommitChanges();
            }

            return slab;
        }

        private TSModel.Beam InsertBeam(double width, double height, Point input1, Point input2)
        {
            try
            {
                TSModel.Model model = new TSModel.Model();
                TSModel.Beam beam = new TSModel.Beam();

                beam.Name = "GIRDER";
                beam.Profile.ProfileString = (width + "x" + height);
                beam.Material.MaterialString = "C24";
                beam.Class = "11";

                double tlc = _data.TopLeftCut;
                double trc = _data.TopRightCut;

                //if (_data.TopLeftCut > 0 || _data.TopRightCut > 0)
                //{

                //}

                if (!beam.Insert())
                {
                    MessageBox.Show("Inserting beam failed.", "error");
                }
                else
                {
                    model.CommitChanges();
                }

                return beam;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Check internal beam settings.");
                throw;
            }
        }

        private TSModel.Beam InsertAddBeam(double width, double height, Point input1, Point input2)
        {
            return null;
        }

        public override List<InputDefinition> DefineInput()
        {
            var list = new List<InputDefinition>();
            try
            {
                var picker = new Picker();
                var pt1 = picker.PickPoint("Pick the starting point.");
                var pt2 = picker.PickPoint("Pick the end point.");
                list.Add(new InputDefinition(pt1, pt2));
            }
            catch
            {
                //ignored.
            }

            return list;
        }
    }
}
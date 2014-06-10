using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minim {
    class MathNew {
        public static bool IntersectionPoint(PointViewModel P1_a, PointViewModel P2_a, PointViewModel P1_b, PointViewModel P2_b) {
            //double A1, B1, C1, A2, B2, C2;
            //A1 = Y1.PosY - X1.PosY;
            //B1 = X1.PosX - Y1.PosX;
            //C1 = Y1.PosX * X1.PosY - X1.PosX * Y1.PosY;
            //A2 = Y2.PosY - X2.PosY;
            //B2 = X2.PosX - Y2.PosX;
            //C2 = Y2.PosX * X2.PosY - X2.PosX * Y2.PosY;
            //if (A1 == 0 && A2 == 0) {
            //    if (B1 == 0 && B2 == 0) {
            //        return true;
            //    } else {
            //        double tam1 = C1 / B1;
            //        double tam2 = C2 / B2;
            //        if (tam1 == tam2)
            //            if (SoLon(DoDai(X2, X1), DoDai(X2, Y1)) / DoDai(X1, Y1) < 1)
            //                return true;
            //            else {
            //                if (SoLon(DoDai(Y2, X1), DoDai(Y2, Y1)) / DoDai(X1, Y1) < 1)
            //                    return true;
            //                else
            //                    return false;
            //            }
            //        else
            //            return false;
            //    }
            //} else {
            //    double tam1, tam2;
            //    tam1 = A1 * B2 - A2 * B1;
            //    tam2 = B1 * C2 - B2 * C1;
            //    if (tam1 != 0) {
            //        //Cat
            //        PointViewModel GD;
            //        GD = new PointViewModel((-B2 * C1 + B1 * C2) / tam1, (A2 * C1 - A1 * C2) / tam1);
            //        if ((SoLon(DoDai(GD, X1), DoDai(GD, Y1)) / DoDai(X1, Y1) <= 1) && (SoLon(DoDai(GD, X2), DoDai(GD, Y2)) / DoDai(X2, Y2) <= 1))
            //            return true;
            //        else
            //            return false;
            //    } else {
            //        if (tam2 == 0)
            //            return false;   //Song song
            //        else {
            //            //Trung
            //            if (SoLon(DoDai(X2, X1), DoDai(X2, Y1)) / DoDai(X1, Y1) < 1)
            //                return true;
            //            else {
            //                if (SoLon(DoDai(Y2, X1), DoDai(Y2, Y1)) / DoDai(X1, Y1) < 1)
            //                    return true;
            //                else
            //                    return false;
            //            }
            //        }
            //    }
            //}
            //} 

            double A1 = P2_a.PosY - P1_a.PosY;
            double B1 = P1_a.PosX - P2_a.PosX;
            double C1 = A1 * P1_a.PosX + B1 * P1_a.PosY;

            double A2 = P2_b.PosY - P1_b.PosY;
            double B2 = P1_b.PosX - P2_b.PosX;
            double C2 = A2 * P1_b.PosX + B2 * P1_b.PosY;

            double det = A1 * B2 - A2 * B1;
            if (det == 0) {
                //Xet song song, khong trung, return false
                if (B1 * C2 != B2 * C1) {
                    return false;
                } else {
                    //Xet trung phuong, giao, return true                    
                    if (IsMiddle(new PointViewModel(P1_a.PosX, P2_a.PosX), new PointViewModel(P1_a.PosX, P2_a.PosX), P1_b.PosX) &&
                        IsMiddle(new PointViewModel(P1_a.PosY, P2_a.PosY), new PointViewModel(P1_a.PosY, P2_a.PosY), P1_b.PosY)) {
                        return true;
                    } else {
                        if (IsMiddle(new PointViewModel(P1_a.PosX, P2_a.PosX), new PointViewModel(P1_a.PosX, P2_a.PosX), P2_b.PosX) &&
                            IsMiddle(new PointViewModel(P1_a.PosY, P2_a.PosY), new PointViewModel(P1_a.PosY, P2_a.PosY), P2_b.PosY)) {
                            return true;
                        }
                    }

                    if (IsMiddle(new PointViewModel(P1_b.PosX, P2_b.PosX), new PointViewModel(P1_b.PosX, P2_b.PosX), P1_a.PosX) &&
                        IsMiddle(new PointViewModel(P1_b.PosY, P2_b.PosY), new PointViewModel(P1_b.PosY, P2_b.PosY), P1_a.PosY)) {
                        return true;
                    } else {
                        if (IsMiddle(new PointViewModel(P1_b.PosX, P2_b.PosX), new PointViewModel(P1_b.PosX, P2_b.PosX), P2_a.PosX) &&
                            IsMiddle(new PointViewModel(P1_b.PosY, P2_b.PosY), new PointViewModel(P1_b.PosY, P2_b.PosY), P2_a.PosY)) {
                            return true;
                        }
                    }                    
                }
                //Xet trung phuong, khong giao, return false
                return false;                

            } else {
                double x = (B2 * C1 - B1 * C2) / det;
                double y = (A1 * C2 - A2 * C1) / det;

                if (IsMiddle(new PointViewModel(P1_a.PosX, P2_a.PosX), new PointViewModel(P1_a.PosX, P2_a.PosX), x) &&
                    IsMiddle(new PointViewModel(P1_a.PosY, P2_a.PosY), new PointViewModel(P1_a.PosY, P2_a.PosY), y)) {

                        if (IsMiddle(new PointViewModel(P1_b.PosX, P2_b.PosX), new PointViewModel(P1_b.PosX, P2_b.PosX), x) &&
                        IsMiddle(new PointViewModel(P1_b.PosY, P2_b.PosY), new PointViewModel(P1_b.PosY, P2_b.PosY), y)) {

                            return true;
                        } else {
                            return false;
                        }
                } else {
                    return false;
                }
            }           
        }

        public static bool IsMiddle(PointViewModel P1, PointViewModel P2, double x) {
            if ((P1.PosX < P1.PosY ? P1.PosX : P1.PosY) < x && x < (P2.PosX > P2.PosY ? P2.PosX : P2.PosY)) {
                return true;
            } else {
                return false;
            }
        }
    

        public static double DoDai(PointViewModel A, PointViewModel B) {
            double DoDai = Math.Sqrt((A.PosX - B.PosX) * (A.PosX - B.PosX) + (A.PosY - B.PosY) * (A.PosY - B.PosY));
            return DoDai;
        }

        public static double SoLon(double a, double b) {
            if (a >= b) return a;
            else return b;
        }

        public static bool AddConnPoint(List<PointViewModel> m_lp, List<ConnectorViewModel> m_lc, ref List<PointViewModel> m_lsp, ref List<ConnectorViewModel> m_lsc, PointViewModel m_p) {
            //m_lsc = new List<ConnectorViewModel>();
            //m_lsp = new List<PointViewModel>();
            //for (int i = 0; i < m_lc.Count; i++) {
            //    for (int j = i; j < m_lc.Count; j++) {
            //        if (m_lc[i].PointId1 == m_p.Id && !IntersectionPoint(m_lp[m_lc[i].PointId2], m_p, m_lp[m_lc[j].PointId1], m_lp[m_lc[j].PointId2])) {
            //            m_lsp.Add(m_lp[m_lc[i].PointId2]);
            //            m_lsc.Add(m_lc[i]);
            //        } else
            //            if (m_lc[i].PointId2 == m_p.Id && !IntersectionPoint(m_lp[m_lc[i].PointId1], m_p, m_lp[m_lc[j].PointId1], m_lp[m_lc[j].PointId2])) {
            //                m_lsp.Add(m_lp[m_lc[i].PointId1]);
            //                m_lsc.Add(m_lc[i]);
            //            }
            //    }
            //}
            int count = 0;
            int countCorrect = 0;
            foreach (ConnectorViewModel connector in m_lc) {
                if (App.GameMainViewModel.AlreadyConnector.Contains(connector.Id)) {
                    continue;
                }
                if ((connector.PointId1 == m_p.Id && connector.PointId2 != m_p.Id) || (connector.PointId1 != m_p.Id && connector.PointId2 == m_p.Id )) {
                    countCorrect++;
                    if (NotIntersectionConnectors(connector, m_p, m_lc, m_lp)) {
                        count++;
                        m_lsc.Add(connector);

                        if (connector.PointId1 == m_p.Id) {
                            m_lsp.Add(m_lp[connector.PointId2]);
                        }

                        if (connector.PointId2 == m_p.Id) {
                            m_lsp.Add(m_lp[connector.PointId1]);
                        }
                    }
                }
            }
            if (count == countCorrect) {
                return true;
            } else {
                m_lsp.Clear();
                m_lsc.Clear();
                return false;
            }
        }

        public static bool NotIntersectionConnectors(ConnectorViewModel m_c, PointViewModel m_p, List<ConnectorViewModel> m_lc, List<PointViewModel> m_lp) {
            foreach (ConnectorViewModel connector in m_lc) {
                if (App.GameMainViewModel.AlreadyConnector.Contains(connector.Id)) {
                    continue;
                }
                if (connector.Id != m_c.Id && connector.PointId1 != m_p.Id && connector.PointId2 != m_p.Id) {
                    if (IntersectionPoint(m_lp[m_c.PointId1], m_lp[m_c.PointId2], m_lp[connector.PointId1], m_lp[connector.PointId2])) {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

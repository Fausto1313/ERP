<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[SaleOrderLine]].
 *
 * @see SaleOrderLine
 */
class SaleOrderLineQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return SaleOrderLine[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return SaleOrderLine|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}

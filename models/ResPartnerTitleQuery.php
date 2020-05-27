<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[ResPartnerTitle]].
 *
 * @see ResPartnerTitle
 */
class ResPartnerTitleQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return ResPartnerTitle[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return ResPartnerTitle|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}

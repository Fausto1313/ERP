<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[ResCountryGroup]].
 *
 * @see ResCountryGroup
 */
class ResCountryGroupQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return ResCountryGroup[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return ResCountryGroup|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
